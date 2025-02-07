import {
    changeHandler,
    closedHandler,
    contentReadyHandler,
    copyHandler,
    cutHandler,
    pasteHandler,
    disposeHandler,
    enterKeyHandler,
    focusInHandler,
    focusOutHandler,
    initializedHandler,
    inputHandler,
    keyDownHandler,
    keyUpHandler,
    keyPressHandler,
    openedHandler,
    optionChangedHandler,
    valueChangedHandler,
} from "../AllMethodEvent/Event.js"









$(document).ready(function () {

    $("#numberBox").dxNumberBox({
        type: "decimal" , // fixedpoint,persent,currency
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
        mode: "number", // uses phone keyboard default teext , number , // number , txt,tel
        readOnly: false,
        showClearButton: true,
        showSpinButtons: true,
        step: 20,
        visible: true,
        useLargeSpinButtons:true,
        value:"5",



    })

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


    $("#NumBoxThree").dxNumberBox({
        onCopy: copyHandler,
        onCut: cutHandler,
        onContentReady: contentReadyHandler,
        onValueChanged: valueChangedHandler,
        onPaste: pasteHandler,
        onKeyPress: keyPressHandler,
        onKeyUp: keyUpHandler,
        onOptionChanged: optionChangedHandler,
        onFocusIn: focusInHandler
    })

  
})