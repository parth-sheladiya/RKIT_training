
$(document).ready(function () {
 let textInst=   $("#TextAreaField").dxTextArea({
        accessKey: "J", // by default undefined
        activeStateEnabled: true, // default false
        disabled: false, // default false
        // height property is not in effect if autoResizeEnabled is set to true.
        autoResizeEnabled: true, // default false
        focusStateEnabled: true, // default true
        // height:"200px",
        //height: function () {
        //    return window.innerHeight /5;
        //}, // default undefined
        // that's why difference btwn height maxhight 
        elementAttr:{
            id:"charCount"
        },
        buttons:[
            {
                name:"cust",
                location:"after",
                options:{
                    text:"reset",
                    onClick:()=>{
                        textInst.resetOption("value")
                    }
                }
            }
        ],
        maxHeight: "200px", // default undefined
        hint: "this is text area content", // default null
        maxLength: 100, // default null
        minHeight: "10px", //undefined
        name: "parthtextArea", // default null
        onChange: function (e) {  // default null    
            console.log("Change event triggered", e);
        },            
        onContentReady: function (e) {  // default null
            console.log("Content Ready event triggered", e);
        }, 
        onCut: function (e) {
            console.log("Cut event triggered", e);
        }, // default null
        onEnterKey: function (e) {
            console.log("Enter Key event triggered", e);
        }, // default null
        // if focusstateenbled is flase then they have not working in and out
        onFocusIn: function (e) {
            console.log("Focus In event triggered", e);
        },
        onFocusOut: function (e) {
            console.log("Focus Out event triggered", e);
        },
        onInput: function(e) {
            $("#charCount").text("Characters: " + e.event.target.value.length);
        },
        onOpened: function (e) {
            console.log("Opened event triggered", e);
        },
        onValueChanged: function (e) {
            console.log("Value Changed event" + e.value, e);
        },
        placeholder: "enter your feedback", // default null
        spellcheck: true, // check spelling  default false
       stylingMode: "underlined", // filled
        value: "hello from parth",
       // label:"textarea", not working in 21.1


    }).dxTextArea("instance");  
})