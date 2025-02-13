import 
{ 
    optionChangedHandler,
    valueChangedHandler,
} from "../AllMethodEvent/Event.js"


$(document).ready(function () {
    $("#RadioSimple").dxRadioGroup({
        hint: "This is a radio group",
        items: priorities,
        value: priorities[3],
        layout: "horizontal",
        onOptionChanged: optionChangedHandler,
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
