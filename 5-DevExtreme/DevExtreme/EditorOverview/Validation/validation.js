$(document).ready(function () {

    // First Name Validation
    $("#firstname-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "First Name",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "First Name is required",
            },
            {
                type: "stringLength",
                min: 1,
                max: 22,
                message: "First Name must be between 1 and 22 characters!",
            },
        ],
    });

    // Last Name Validation
    $("#lastname-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "Last Name",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "Last Name is required",
            },
            {
                type: "stringLength",
                min: 1,
                max: 10,
                message: "Last Name must be between 1 and 10 characters!",
            },
        ],
    });

    // Email Validation
    $("#email-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "Email",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "Email is required",
            },
            {
                type: "email",
                message: "Invalid email address!",
            },
        ],
    });

    // Password Validation
    $("#password-validation").dxTextBox({
        validationMessageMode: "always",
        mode: "password",
    }).dxValidator({
        name: "Password",
        onValidated: showSuccessMessage,
        validationRules: [
            {
            type: "required",
            message: "Password is required",
        },
        {
            type: "stringLength",
            min: 6,
            message: "Password must be at least 6 characters long!",
        },
        {
            type: "custom",
            validationCallback: function (e) {
                return /[A-Z]/.test(e.value);  
            },
            message: "Must contain at least one uppercase letter!",
        },
        {
            type: "custom",
            validationCallback: function (e) {
                return /[a-z]/.test(e.value); 
            },
            message: "Must contain at least one lowercase letter!",
        },
        {
            type: "custom",
            validationCallback: function (e) {
                return /\d/.test(e.value);  
            },
            message: "Must contain at least one number!",
        },
        {
            type: "custom",
            validationCallback: function (e) {
                return /[@$!%*?&]/.test(e.value);  
            },
            message: "Must contain at least one special character (@, $, !, %, *, ?, &)!",
        },
        ],
    });

    // Confirm Password Validation
    $("#confirm-password-validation").dxTextBox({
        validationMessageMode: "always",
        mode: "password",
    }).dxValidator({
        name: "Confirm Password",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "Confirm Password is required",
            },
            {
                type: "compare",
                comparisonTarget: function () {
                    return $("#password-validation").dxTextBox("instance").option("value");
                },
                message: "Passwords do not match!",
            },
        ],
    });

    // Aadhaar Number Validation
    $("#Aadhar-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "Aadhar Number",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "Aadhar Number is required",
            },
            {
                type: "pattern",
                pattern: /^[2-9]{1}[0-9]{11}$/,
                message: "Aadhar Number must be a valid 12-digit number (First digit cannot be 0 or 1)!",
            },
        ],
    });

    // Birthdate Validation
    $("#birthdate-validation").dxDateBox({
        validationMessageMode: "always",
        type: "date",
    }).dxValidator({
        name: "Birthdate",
        onValidated: showSuccessMessage,
        validationRules: [
            {
                type: "required",
                message: "Birthdate is required",
            },
            {
                type: "range",
                min: new Date(1950, 0, 1),
                max: new Date(),
                message: "Date is Not Valid",
            },
        ],
    });

    // Register Button
    $("#button").dxButton({
        text: "Register",
        type: "success",
        stylingMode: "outlined",
        useSubmitBehavior: true,
        onClick: function () {
            let result = DevExpress.validationEngine.validateGroup();
            console.log(result);
            if (result.isValid) {
                DevExpress.ui.notify("Registration Successful!", "success", 5000);
            } else {
                DevExpress.ui.notify("Please fix the errors!", "error", 5000);
            }
        },
    });

});

// Function to show success message
function showSuccessMessage(e) {
    if (e.isValid) {
        DevExpress.ui.notify(
            e.component.option("name") + " Validated Successfully!",
            "success",
            2000
        );
    }
}
