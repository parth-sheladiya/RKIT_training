
$(document).ready(function () {
    const data = [
        { ID: 1, Name: 'Banana', Category: 'Fruits' },
        { ID: 2, Name: 'Cucumber', Category: 'Vegetables' },
        { ID: 3, Name: 'Apple', Category: 'Fruits' },
        { ID: 4, Name: 'Tomato', Category: 'Vegetables' },
        { ID: 5, Name: 'Apricot', Category: 'Fruits' },
        { ID: 6, Name: 'Carrot', Category: 'Vegetables' },
        { ID: 7, Name: 'Strawberry', Category: 'Fruits' },
        { ID: 8, Name: 'Potato', Category: 'Vegetables' },
        { ID: 9, Name: 'Orange', Category: 'Fruits' },
        { ID: 10, Name: 'Lettuce', Category: 'Vegetables' },
        { ID: 11, Name: 'Pineapple', Category: 'Fruits' },
        { ID: 12, Name: 'Cabbage', Category: 'Vegetables' },
        { ID: 13, Name: 'Mango', Category: 'Fruits' },
        { ID: 14, Name: 'Onion', Category: 'Vegetables' },
        { ID: 15, Name: 'Peach', Category: 'Fruits' }
    ];
// let a ="pppppp"
    let filterType = "contains";
    

  let selectInst=  $("#SelectBox").dxSelectBox({
        // data
        dataSource : new DevExpress.data.DataSource({
            store: data,
            type: "array",
            key: "ID",
            group: "Category",
        }),
        // show console.log
        valueExpr: "ID",
        noDataText:"no data",
        // show ui
        displayExpr: "Name",
        // displayValue:a,
        // search fields
        searchEnabled: true,
        spellcheck: true,
        searchMode: filterType,
        grouped: true,
        placeholder: "please select item",
        hint: "this is select box",
       
        // just example purpose
        dropDownOptions: {
            width: 300,  
            height: 200, 
            closeOnOutsideClick: true,
            showTitle: true, 
            title: "Select a Fruit" 
        },
        showSelectionControls:true,
        onCustomItemCreating: function(e){
            e.customItem = e.text;
            console.log("set",e.customItem)
        },
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
            console.log("Previous value: ", e.previousValue); // Previously selected items
            console.log("New value: ", e.value);
            console.log("selectedItem", e.component.option("selectedItem"))
            console.log("a",e.component.option("displayValue"))
           
        },
        onItemClick: function(e) {
            DevExpress.ui.notify("hello","success",2000)
            console.log("Item clicked: ", e.itemData);
        }

    }).dxSelectBox("instance")
   

    $("#checkBoxContainsMethod").dxCheckBox({
        text: "Contains Search",
        value: false,
        onValueChanged: function (e) {
            if (e.value) {
                filterType = "contains";
                selectInst.option("searchMode", "contains");
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
                selectInst.option("searchMode", "startswith");
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
            console.log("initialized event fired - Widget instance created!", e);
        },
    });
})


