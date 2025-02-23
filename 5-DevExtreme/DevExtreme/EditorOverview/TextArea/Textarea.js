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

import {
    beginUpdate,
    blur,
    close,
    dispose,
    element,
    endUpdate,
    field,
    focus,
    instance,
    open,
    option,
    registerKeyHandler,
    reset,
}
    from "../AllMethodEvent/Method.js"

$(document).ready(function () {
    $("#TextAreaField").dxTextArea({
        accessKey: "J", // by default undefined
        activeStateEnabled: true, // default false
        disabled: false, // default false
        autoResizeEnabled: true, // default false
        focusStateEnabled: true, // default true
        // height:"200px",
        //height: function () {
        //    return window.innerHeight /5;
        //}, // default undefined
        // that's why difference btwn height maxhight 
        maxHeight: "200px", // default undefined
        hint: "this is text area content", // default null
        maxLength: 100, // default null
        minHeight: "10px", //undefined
        name: "parthtextArea", // default null
        onChange: changeHandler,            // default null      
        onContentReady: contentReadyHandler,   // default null
        onCut: cutHandler, // default null
        onDisposing: disposeHandler, // deafult null
        onEnterKey: enterKeyHandler, // default null
        // if focusstateenbled is flase then they have not working in and out
        onFocusIn: focusInHandler, // default null
        onFocusOut: focusOutHandler, //default nulll
        onInput: inputHandler, // default null
        onOptionChanged: optionChangedHandler, // default null
        onValueChanged: valueChangedHandler, // default null
        placeholder: "enter your feedback", // default null
        spellcheck: true, // check spelling  default false
       stylingMode: "underlined", // filled
        value: "hello from parth",
       // label:"textarea", not working in 21.1


    });


    var textAreaInstance = $("#TextAreaField").dxTextArea("instance");

    element(textAreaInstance);
    console.log(element(textAreaInstance));

    instance(textAreaInstance);
    console.log(instance(textAreaInstance));

   // dispose(textAreaInstance);

   textAreaInstance.off("onCopy", copyHandler);
    
})