$(document).ready(function () {

    console.log("document is ready to use");
    // Initialize the first checkbox
    $("#checkBoxContainer").dxCheckBox({
        text: "Accept terms and conditions",
        name: "termsAccepted",
        disabled: false,
        accesskey: "a", 
        focusStateEnabled: true,
        hint: "Click to accept terms and conditions",
        tabIndex: 2,
        value: undefined,
        
    });

    // Initialize the second checkbox
    $("#checkBoxContainer2").dxCheckBox({
        text: "Accept terms and conditions",
        tabIndex: 1,
        rtlEnabled: true
    });
    
    // Get the element of the second checkbox and log it
    var getEle = $("#checkBoxContainer2").dxCheckBox("instance").element();
    console.log("get element is ");
    console.log(getEle);

    // Initialize the third checkbox
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
    CheckBoxInstanceThree.option("value", true); // Change the checked state
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

        // Set the checkbox value to true (checked)
        CheckBoxInstanceThree.option("value", true);
    })
    // End update to refresh the UI
    CheckBoxInstanceThree.endUpdate();

        
        // $("#checkBoxContainer2").dxCheckBox("dispose");
        // $("#checkBoxContainer2").remove();
})