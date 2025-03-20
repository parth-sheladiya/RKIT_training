

$(document).ready(function () {
    $("#RadioSimple").dxRadioGroup({
        // hint
        hint: "This is a radio group",
        // items data.js
        dataSource: priorities,
        // default set on ui
        value: priorities[3],
        // vertical horizontal
        layout: "horizontal",
        // option changes handler
        onContentReady: function (e) {
            console.log("Content Ready event triggered", e);
        },
        onValueChanged: function (e) {
            console.log("Value Changed event triggered. New Value: " + e.value, e);
        },
        hoverStateEnabled: false,
        
    });


    // Disable Button
    $("#btnDisabled").dxButton({
        text: "Disable Radio Group",
        onClick: function () {
            $("#RadioSimple").dxRadioGroup("instance").option("disabled", true);
        }
    });

   
});
