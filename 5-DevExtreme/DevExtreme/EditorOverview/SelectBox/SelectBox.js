import {
    changeHandler,
    closedHandler,
    contentReadyHandler,
    copyHandler,
    cutHandler,
    pasteHandler,
    disposeHandler,
    enterKeyHandler,
    focusInHandler,
    focusOutHandler,
    initializedHandler,
    inputHandler,
    keyDownHandler,
    keyUpHandler,
    keyPressHandler,
    openedHandler,
    optionChangedHandler,
    valueChangedHandler,
} from "../AllMethodEvent/Event.js";


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
        searchEnabled: true,
        searchMode: filterType,
        onValueChanged: valueChangedHandler,
        grouped: true,
        placeholder: "please select item",
        hint:"this is select box"
    })
    var selectBoxInstance = $("#SelectBox").dxSelectBox("instance")

    $("#checkBoxContainsMethod").dxCheckBox({
        text: "Contains Search",
        value: true,
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
        value: false,
        onValueChanged: function (e) {
            if (e.value) {
                filterType = "startswith";
                selectBoxInstance.option("searchMode", "startswith");
                $("#checkBoxContainsMethod").dxCheckBox("instance").option("value", false);
            }
        }
    })
})