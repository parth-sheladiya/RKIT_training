

$(document).ready(function () {
    $("#ButtonBox").dxButton({
        // show text on ui
        text: "click me",
        // button type
        type:"normal",
        // click handler
        onClick: function () {
            DevExpress.ui.notify("button clicked")
        },
        // css style
        stylingMode: "outlined",
        // icon
        // search deveextreme icons  different icons are available in devextreme 
        icon: "activefolder" 

    })

    $("#successButtonBox").dxButton({
        // show text on ui
        text: "sucess",
        // button type
        type: "success",
        // click handler
        stylingMode: "text", 
        // icon
        icon: "comment",
        onClick: function () {
            DevExpress.ui.notify("success button clicked ","success",6000)
        }
    })

    $("#defaultButtonBox").dxButton({
        text: "default button",
        type: "default",
        stylingMode: "contained", //outlined text
        onClick: function () {
            DevExpress.ui.notify("default button clicked","info",4000)
        },
        icon:"airplane"
    })

    $("#DengerButton").dxButton({
        text: "danger button",
        type: "danger",
        stylingMode: "contained",
        onClick: function () {
            DevExpress.ui.notify("danger button clicked","warning",1000)
        },
        icon:"comment"
    })
})