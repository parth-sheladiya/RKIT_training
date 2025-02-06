$(document).ready(function () {

    $("#basicDropDownBox").dxDropDownBox({
        name: ["parth", "jay", "deep", "jeel"],
        placeholder: "select a value",
        acceptCustomValue: false,
        disabled: false,
        readonly: false,
        hint: "this is dropdown box",
        displayExpr: "name",
        height: "100px",
        width: "500px",
        showDropDownButton: true,

    })

    var names = ["parth", "raj", "deep", "jay", "jeel"];

    $("#dropDownBox").dxDropDownBox({
        contentTemplate: function (e) {
            var $list = $("<div>").dxList({
                dataSource: names,
                selectionMode: "multiple", // single
                showSelectionControls: true,
                deferRendering: true
            });
            return $list;
        },

        onClosed: function () {
            alert("dropdown close");
        },
        //buttons: [
        //    {
        //        name: "clear",
        //        location: "after",
        //        options: {
        //            text: "❌",
        //            onClick: function () {
        //                console.log("click call");
        //            }
        //        },
        //    }
        //],

        hoverStateEnabled: true,
        showClearButton: true, // Make sure this is set to true
        showDropDownButton: true // Also, enable the dropdown button explicitly
    });


    var dropDownInstance = $("#dropDownBox").dxDropDownBox("instance")
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