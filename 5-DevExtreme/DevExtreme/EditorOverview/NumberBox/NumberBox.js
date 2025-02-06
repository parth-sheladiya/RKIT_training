$(document).ready(function () {

    $("#numberBox").dxNumberBox({
        placeholder:"this is number box",
        // short cut key 
        accessKey: "j",
        //when the widget is focused or clicked
        activeStateEnabled: true,
        // bydefault false
        // if true then disabled
        disabled: false,  
        elementAttr: {
            //customid
            id: "id-num-box",
            //customclass
            class:"class-num-box"
        },
        hint: "this is number box",
        max: 1000,
        min: 5,
        mode: "number", // default teext , number , // number , txt,tel
        readOnly: false,
        showClearButton: true,
        showSpinButtons: true,
        step: 20,
        visible: true,
        useLargeSpinButtons:true,
        value:"5",



    })
})