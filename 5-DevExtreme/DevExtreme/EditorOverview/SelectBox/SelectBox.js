
$(document).ready(function () {
    const data = [{
        ID: 1,
        Name: 'Banana',
        Category: 'Fruits'
    }, {
        ID: 2,
        Name: 'Cucumber',
        Category: 'Vegetables'
    }, {
        ID: 3,
        Name: 'Apple',
        Category: 'Fruits'
    }, {
        ID: 4,
        Name: 'Tomato',
        Category: 'Vegetables'
    }, {
        ID: 5,
        Name: 'Apricot',
        Category: 'Fruits'
    }]
    let filterType = "contains";
    const dataSource = new DevExpress.data.DataSource({
        store: data,
        type: "array",
        key: "ID",
        group: "Category"
    });

    $("#SelectBox").dxSelectBox({
        // data
        dataSource: dataSource,
        // show console.log
        valueExpr: "Category",
        // show ui
        displayExpr: "Name",
        // search fields
        //searchEnabled: true,
        searchMode: filterType,
        grouped: true,
        placeholder: "please select item",
        hint: "this is select box",
        onChange: function (e) {
            console.log("Change event triggered", e);
        },
        onCopy: function (e) {
            console.log("Copy event triggered", e);
        },
        onCut: function (e) {
            console.log("Cut event triggered", e);
        },
        onPaste: function (e) {
            console.log("Paste event triggered", e);
        },
        onContentReady: function (e) {
            console.log("Content Ready event triggered", e);
        },
        onEnterKey: function (e) {
            console.log("Enter Key event triggered", e);
        },
        onFocusIn: function (e) {
            console.log("Focus In event triggered", e);
        },
        onFocusOut: function (e) {
            console.log("Focus Out event triggered", e);
        },
        onOpened: function (e) {
            console.log("Opened event triggered", e);
        },
        onValueChanged: function (e) {
            console.log("Value Changed event triggered. New Value: " + e.value, e);
        }

    })
    var selectBoxInstance = $("#SelectBox").dxSelectBox("instance")

    $("#checkBoxContainsMethod").dxCheckBox({
        text: "Contains Search",
        value: false,
        onValueChanged: function (e) {
            if (e.value) {
                filterType = "contains";
                selectBoxInstance.option("searchMode", "contains");
                $("#checkBoxStartWithMethod").dxCheckBox("instance").option("value", false);
            }
        }

    })

    $("#checkBoxStartWithMethod").dxCheckBox({
        text: "startwith Search",
        value: true,
        onValueChanged: function (e) {
            if (e.value) {
                filterType = "startswith";
                selectBoxInstance.option("searchMode", "startswith");
                $("#checkBoxContainsMethod").dxCheckBox("instance").option("value", false);
            }
        }
        })

    $("#dropdown").dxSelectBox({
        dataSource: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                console.log("Fetching data from server...");
                return new Promise((resolve) => {
                    setTimeout(() => {
                        resolve(["Apple", "Banana", "Mango", "Grapes"]);
                        console.log(" Data Loaded!");
                    }, 9000); 
                });
            }
        }),
        placeholder: "Select a fruit",
       
        onContentReady: function (e) {
            console.log("contentReady event fired - Content is fully loaded!");
        },
        onInitialized: function (e) {
            console.log("⚡ initialized event fired - Widget instance created!", e);
        },
    });
})


