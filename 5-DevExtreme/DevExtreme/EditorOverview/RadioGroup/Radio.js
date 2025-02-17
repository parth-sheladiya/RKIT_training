import 
{ 
    optionChangedHandler,
    valueChangedHandler,
} from "../AllMethodEvent/Event.js"


$(document).ready(function () {
    $("#RadioSimple").dxRadioGroup({
        // hint
        hint: "This is a radio group",
        // items data.js
        items: priorities,
        // default set on ui
        value: priorities[3],
        // vertical horizontal
        layout: "horizontal",
        // option changes handler
        onOptionChanged: optionChangedHandler,
        // value chages handler
        onValueChanged: valueChangedHandler,
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
