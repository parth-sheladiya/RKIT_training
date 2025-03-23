$(document).ready(function () {

    DevExpress.ui.dxCheckBox.defaultOptions({
       
        options: { 
            hoverStateEnabled: false,
            text: "Accept terms and conditions",
        } 
        
    });
    console.log("document is ready to use");
    // Initialize the first checkbox
    $("#checkBoxContainer").dxCheckBox({
        // show text on ui
        // text: "Accept terms and conditions",
        // it is use to send name in backend data
        name: "termsAccepted",
        // by default false 
        disabled: false,
        // alt+a with out mouse click
        accessKey: "=", 
        activeStateEnabled:true,
        //  access to tab key  if false to not navigate to tab key by default true
        focusStateEnabled: true,
        // mouse move on check then they will show hint
        hint: "Click to accept terms and conditions",
        // tabindex setup
        tabIndex: 2,
        // check box is tick or unticked
        value: true,
        elementAttr:{
            id: "elementId",
            class: "class-name"
        },
        // if true then not work val error
        isValid: false,
        // doubt
       // validationStatus:"pending",
        validationError: { message: "You must accept the terms!" },
        onOptionChanged: function(e) {
            console.log("E",e)
            console.log("Option changed: ", e.name, "New Value:", e.value);
        }
        
    });


    // second instance
    $("#checkBoxContainer2").dxCheckBox({
        // text: "Accept terms and conditions",
        tabIndex: 1,
        rtlEnabled: true
    });
    
    // Get the element of the second checkbox and log it
    // it is use to debug abd styling purpose
    var getEle = $("#checkBoxContainer2").dxCheckBox("instance").element();
    console.log("checkBoxContainer2 get element is ",getEle);
    
    // use elementAttr
    $("#elementId").dxCheckBox("instance").option("value", false);

    // Initialize the third checkbox
    // other way to create checkbox
    var checkBoxInstance = $("#checkBoxContainer").dxCheckBox("instance");
    //checkBoxInstance.resetOption("hint")
    
    $("#checkBoxContainer3").dxCheckBox({
        // text: "Subscribe to my follotips",
        value: true,
        disabled:true
    });
 


    // instance()
    var CheckBoxInstanceThree = $("#checkBoxContainer3").dxCheckBox("instance");
   // CheckBoxInstanceThree.resetOption("value")
    console.log("hii",CheckBoxInstanceThree.option("disabled"))
    // on (event name , event handler)
    $("#checkBoxContainer2").on("click", function () {
        CheckBoxInstanceThree.focus();
    })
    // Begin update method
    CheckBoxInstanceThree.beginUpdate();

    // Update multiple properties
    CheckBoxInstanceThree.option("value", false); // Change the checked state
    // CheckBoxInstanceThree.option("text", "Unsubscribe my follotips"); // Change the text
    CheckBoxInstanceThree.endUpdate();
    // option changed
    CheckBoxInstanceThree.on("optionChanged", function () {
        console.log("optionChanged")
    })
    // value changhed
    CheckBoxInstanceThree.on("valueChanged", function (e) {
        console.log("value changed");
        console.log("new value is", e.value)
    })
    // register key handler (key,handlker)
    // method
    CheckBoxInstanceThree.registerKeyHandler("enter", function () {
        console.log("You pressed Enter!");

        
    })
    // End update to refresh the UI
    CheckBoxInstanceThree.endUpdate();

        
        // $("#checkBoxContainer2").dxCheckBox("dispose");
        // $("#checkBoxContainer2").remove();
})