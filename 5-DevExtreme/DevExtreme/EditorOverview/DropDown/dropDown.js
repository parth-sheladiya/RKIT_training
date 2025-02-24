$(document).ready(function () {
    var names = ["parth", "raj", "deep", "jay", "jeel"];

    $("#dropDownBox").dxDropDownBox({
        value: "parth", 
        placeholder: "Select a value",
        acceptCustomValue: true,
        disabled: false,
        readonly: false,
        hint: "This is a dropdown box",
        displayExpr: "name",
        height: "100px",
        width: "500px",
        showDropDownButton: true,
        searchEnabled: true, 
        searchExpr: ["name"],
        displayValue: "Select a name",
        stylingMode: "outlined", 

        contentTemplate: function (e) {
            var $list = $("<div>").dxList({
                dataSource: names,
                selectionMode: "multiple", // single
                showSelectionControls: true,
            });
            return $list;
        },

        onClosed: function () {
            alert("Dropdown closed");
        },

        onValueChanged: function (e) {
            console.log("New value: ", e.value);
        },

        hoverStateEnabled: true,
        showClearButton: true, 
        showDropDownButton: true 
    });

    var dropDownInstance = $("#dropDownBox").dxDropDownBox("instance");

    dropDownInstance.on("optionChanged", function (e) {
        console.log(`Option Changed: ${e.name} => ${e.value}`);
    });

    dropDownInstance.on("focus", function () {
        console.log("Dropdown focused");
    });

    dropDownInstance.on("blur", function () {
        console.log("Dropdown lost focus");
    });

    dropDownInstance.on("keydown", function (e) {
        console.log(`Key pressed: ${e.event.key}`);
    });
});