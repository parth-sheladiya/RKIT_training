$(document).ready(function () {
    $("#TextBox").dxTextBox({
        placeholder: "(###) ###-####",
        mask: "(000) 000-0000",
        maskChar: "_",
        maskInvalidMessage: "enter valid phone number",
        maxLength: 10,

    });


    $("#PanCardBox").dxTextBox({
        placeholder: "enter your pancard numjber",
        mask: "LLLLL0000L",
        maxLength: 10,
        maskChar: "_",
        maskInvalidMessage: "enter valid phone number",
        useMaskedValue: true,
        showMaskMode: "onFocus",
    });

    $("#AadharCardBox").dxTextBox({
        placeholder: "enter your aadharcard number",
        // if mask length 12
        // max length 10
        // enter input dield 12 
        mask:"0000 0000 0000",
        maxLength: 10,
        maskChar: "_",
        maskInvalidMessage: "enter valid aadhar number",
        useMaskedValue: true,
        showMaskMode: "never",
    })

    $("#CreditCardBox").dxTextBox({
        placeholder: "enter your credit card number",
        mask: "0000 0000 0000 0000",
        maskChar: "_",
        useMaskedValue: true,
        showMaskMode: "never",
    })



 


})

