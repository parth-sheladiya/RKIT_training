$(document).ready(function () {

    console.log("document is ready to use");
    // Initialize the first checkbox
    $("#checkBoxContainer").dxCheckBox({
        // show text on ui
        text: "Accept terms and conditions",
        // it is use to send name in backend data
        name: "termsAccepted",
        // by default false 
        disabled: false,
        // alt+a with out mouse click
        accesskey: "a", 
        //  access to tab key  if false to not navigate to tab key by default true
        focusStateEnabled: true,
        // mouse move on check then they will show hint
        hint: "Click to accept terms and conditions",
        // tabindex setup
        tabIndex: 2,
        // check box is tick or unticked
        value: true,
        
    });

    // second instance
    $("#checkBoxContainer2").dxCheckBox({
        text: "Accept terms and conditions",
        tabIndex: 1,
        rtlEnabled: true
    });
    
    // Get the element of the second checkbox and log it
    var getEle = $("#checkBoxContainer2").dxCheckBox("instance").element();
    console.log("checkBoxContainer2 get element is ",getEle);
    

    // Initialize the third checkbox
    // other way to create checkbox
    var checkBoxInstance = $("#checkBoxContainer").dxCheckBox("instance");
    $("#checkBoxContainer3").dxCheckBox({
        text: "Subscribe to my follotips",
        value: true
    });

    var CheckBoxInstanceThree = $("#checkBoxContainer3").dxCheckBox("instance");

    // on (event name , event handler)
    $("#checkBoxContainer2").on("click", function () {
        CheckBoxInstanceThree.focus();
    })
    // Begin update to prevent UI refresh while updating properties
    CheckBoxInstanceThree.beginUpdate();

    // Update multiple properties
    CheckBoxInstanceThree.option("value", false); // Change the checked state
    CheckBoxInstanceThree.option("text", "Unsubscribe my follotips"); // Change the text

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
    CheckBoxInstanceThree.registerKeyHandler("enter", function () {
        console.log("You pressed Enter!");

        
    })
    // End update to refresh the UI
    CheckBoxInstanceThree.endUpdate();

        
        // $("#checkBoxContainer2").dxCheckBox("dispose");
        // $("#checkBoxContainer2").remove();
})