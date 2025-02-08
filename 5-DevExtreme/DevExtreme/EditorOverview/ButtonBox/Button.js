$(document).ready(function (){
    $("#ButtonBox").dxButton({
        text: "click me",
        type:"normal",
        onClick: function () {
            DevExpress.ui.notify("button clicked")
        },
        stylingMode: "outlined",
        icon: "activefolder" // search deveextreme icons  different icons are available in devextreme 

    })

    $("#successButtonBox").dxButton({
        text: "sucess",
        type: "success",
        stylingMode: "text", // outlined contained
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