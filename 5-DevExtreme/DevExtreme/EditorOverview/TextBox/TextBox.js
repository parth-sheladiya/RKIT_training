$(document).ready(function () {
    $("#TextBox").dxTextBox({
        // place holder
        placeholder: "(###) ###-####",
        // mask
        mask: "(000) 000-0000",
        // mask char
        maskChar: "_",
        // mask invalid message
        maskInvalidMessage: "enter valid phone number",
        // max length is 10
        maxLength: 10,

    });


    $("#PanCardBox").dxTextBox({
        // place holder
        placeholder: "enter your pancard numjber",
        // mask for pancard
        mask: "LLLLL0000L",
        // max length is 10
        maxLength: 10,
        // mask char
        maskChar: "+",
        // mess
        maskInvalidMessage: "enter valid pancard number",
        // mask value
        //useMaskedValue: true,
        // focus 
        showMaskMode: "onFocus",
    });

    $("#AadharCardBox").dxTextBox({
        placeholder: "enter your aadharcard number",
        // if mask length 12
        // max length 10
        // enter input dield 12 
        mask:"0000 0000 0000",
        // max length is 10
        maxLength: 10,
        // mask char
        maskChar: "_",
        // invalid mess
        maskInvalidMessage: "enter valid aadhar number",
        // mask value
        // if we use mask then do not need to usemask value
        // bcz they have not enter any value
        useMaskedValue: true,
        // never, onFocus, always
        showMaskMode: "never",
    })

    $("#CreditCardBox").dxTextBox({
        // placeholder
        placeholder: "enter your credit card number",
        // mask
        mask: "0000 0000 0000 0000",
        // max char
        maskChar: "_",
        // mask value
        useMaskedValue: true,
        // mode
        showMaskMode: "never",
    })

    $("#PasswordBox").dxTextBox({
        // placeholder
        placeholder: "Enter password",
        // mode
        mode: "password",
        // style
        stylingMode: "filled",
        // btn arr
        buttons: [
            {
                name: "password",
                location: "before", // after
                options: {
                    stylingMode: "filled",
                    onClick: function () {
                        var passwordBox = $("#PasswordBox").dxTextBox("instance");
                        var mode = passwordBox.option("mode");
                        if (mode === "password") {
                            passwordBox.option("mode", "text");
                        } else {
                            passwordBox.option("mode", "password");
                        }
                    }
                }
            }
        ]
    });
})

