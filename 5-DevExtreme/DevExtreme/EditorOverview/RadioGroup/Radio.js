

$(document).ready(function () {
   let radioInst = $("#RadioSimple").dxRadioGroup({
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
        onOptionChanged: function(e){
            console.log("option changed" ,e.name , e.value);
        },
        hoverStateEnabled: false,
        
    }).dxRadioGroup("instance");


    // Disable Button
    $("#btnDisabled").dxButton({
        text: "Disable Radio Group",
        onClick: function () {
           radioInst.option("disabled", true);
           setTimeout(function(){
            radioInst.option("disabled", false);
           },2000)
        }
    });

   
});
