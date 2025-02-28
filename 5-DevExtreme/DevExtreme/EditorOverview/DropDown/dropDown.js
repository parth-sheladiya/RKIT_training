$(document).ready(function () {
    var productName = ["AC", "Led tv", "watch", "shoes", "laptop" , "mobile" ];

    $("#dropDownBox").dxDropDownBox({
        value: "names", 
        dataSource: productName,
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
               // data
               dataSource: productName,
               selectionMode: "multiple", // single multiple
               showSelectionControls: true,
               onSelectionChanged: function (args) {
                   var selectedItems = args.component.option("selectedItems");
                   console.log("select value is ", selectedItems)
                   // selected items are displayed in the dropdownbox
                   $("#dropDownBox").dxDropDownBox("instance").option("value", selectedItems.join(", "));
               }
           });
           return $list;
        },
        //// ?????????
        // not working
        // items:names,
        //dataSource: productName,

        onClosed: function () {
            console.log("Dropdown closed");
        },

        onValueChanged: function (e) {
            //console.log("New value: ", e.value);
            console.log("Previous value: ", e.previousValue); // Before selection change
        console.log("New value: ", e.value);
        },

        hoverStateEnabled: true,
        showClearButton: true,
        showDropDownButton: true
    });
});
