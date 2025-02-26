$(document).ready(function () {
    var names = ["parth", "raj", "deep", "jay", "jeel"];

    $("#dropDownBox").dxDropDownBox({
        value: "names",  // Initially empty
        placeholder: "Select a value",
        acceptCustomValue: true,
        disabled: false,
        readonly: false,
        hint: "This is a dropdown box",
        height: "100px",
        width: "500px",
        showDropDownButton: true,
        searchEnabled: true,
        searchExpr: ["name"],
        stylingMode: "outlined",

        contentTemplate: function (e) {
            var $list = $("<div>").dxList({
                dataSource: names,
                selectionMode: "multiple",
                showSelectionControls: true,
                onSelectionChanged: function (args) {
                    var selectedItems = args.component.option("selectedItems");

                    // selected items are displayed in the dropdownbox
                    $("#dropDownBox").dxDropDownBox("instance").option("value", selectedItems.join(", "));
                }
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
});
