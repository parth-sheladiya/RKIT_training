
$(document).ready(function () {

    $("#numberBox").dxNumberBox({
        // type of number box
        type: "decimal" , // fixedpoint,persent,currency
        // place holder
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
        // max num is 100
        max: 1000,
        // start 5
        min: 5,
        // mode number is we use tel then test in mobile phone
        mode: "number", // uses phone keyboard default teext , number , // number , txt,tel
        readOnly: false,
        // btn
        showClearButton: true,
        // spin btn
        showSpinButtons: true,
        // step we have changes step value
        step: 20,
        // value
        visible: true,
        // large spin btn
        useLargeSpinButtons:true,
        // show on ui value is 5
        value:"5",



    })

    // different format
    $("#formatNumberBox").dxNumberBox({
        format: "00.00",
        format: "#0.#",
        format: "0.00",
        // group sepreator uses lakh,cr 
        format: "#,###",
        // persentage*100
        format: "#0.##%",
        // negative number handle if we use | then format will handle negative number 
        format: "#0.##;(#0.##)",
        format: "Rs #0.00",
        // doubt
        format:"000'-'000"
    })

    // different event
    $("#NumBoxThree").dxNumberBox({
        onCopy: function (e) {
            console.log("Copy event triggered", e);
        },
        onCut: function (e) {
            console.log("Cut event triggered", e);
        },
        onContentReady: function (e) {
            console.log("Content Ready event triggered", e);
        },
        onValueChanged: function (e) {
            console.log("Value Changed event triggered. New Value: " + e.value, e);
        },
        onPaste: function (e) {
            console.log("Paste event triggered", e);
        },
        onKeyPress: function (e) {
            console.log("Key Press event triggered. Key: " + e.key, e);
        },
        onKeyUp: function (e) {
            console.log("Key Up event triggered. Key: " + e.key, e);
        },
        onOptionChanged: function (e) {
            console.log("Option Changed event triggered", e);
        },
        onFocusIn: function (e) {
            console.log("Focus In event triggered", e);
        }
    });

  
})