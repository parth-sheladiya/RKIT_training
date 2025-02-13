$(document).ready(function(){
    // first name

    $("#firstname-validation").dxTextBox({
        validationMessageMode:"always",
    }).dxValidator({
        name: "first name",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000
                );
            }
        },
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
    })

    // last name 
    $("#lastname-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "last name",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000
                );
            }
        },
        validationRules: [
            {
                type: "required",
                message: "last Name is required",
            },
            {
                type: "stringLength",
                min: 1,
                max: 10,
                message: "last Name must be between 1 and 22 characters!",
            },
        ],
    })

    // email checking

    $("#email-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "email",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000
                );
            }
        },
        validationRules: [
            {
                type: "required",
                message: "email is required",
            },
            {
                type: "email",
                message:"invalid email addresss"
            }
        ]
    })

    // password checking
    $("#password-validation").dxTextBox({
        validationMessageMode: "always",
    }).dxValidator({
        name: "password",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000
                );
            }
        },
        validationRules: [
            {
                type: "required",
                message: "email is required",
            },
            {
                type: "pattern",
                pattern: /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/,
                message: "Password must have at least 1 uppercase, 1 lowercase, 1 number, 1 special character and be at least 6 characters long!",
            }

        ]
    })

    // confirm password

    $("#confirm-password-validation")
        .dxTextBox({
            validationMessageMode: "always",
            inputAttr: { "aria-label": "ConfirmPassword" },
            mode: "password",
        })
        .dxValidator({
            name: "Confirm Password",
            onValidated: (e) => {
                if (e.isValid) {
                    DevExpress.ui.notify(
                        e.component.option("name") + " Validated Successfully!",
                        "success",
                        2000
                    );
                }
            },
            validationRules: [
                {
                    type: "required",
                    message: "Confirm Password is required",
                },
                {
                    type: "compare",
                    comparisonTarget: function () {
                        return $("#password-validation")
                            .dxTextBox("instance")
                            .option("value");
                    },
                    message: "Passwords do not match!",
                },
            ],
        });

    $("#Aadhar-validation").dxTextBox({
        name: "aadhar number",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000
                );
            }
        },
        validationRules: [
            {
                type: "required",
                message: "aadhar  Number is required",
            },
            {
                type: "pattern",
                pattern: /^[2-9]{1}[0-9]{11}$/,
                message: "Aadhar Number must be a valid 12-digit number (First digit cannot be 0 or 1)!",
            }
        ]
    })

    $("#birthdate-validation").dxTextBox({
        name: "birthb date",
        onValidated: (e) => {
            if (e.isValid) {
                DevExpress.ui.notify(
                    e.component.option("name") + " Validated Successfully!",
                    "success",
                    2000)
            }
        },
        validationRules: [
            {
                type: "required",
                message:"biirthdate is required"
            },
            {
                type: "range",
                min: new Date(1950, 0, 1),
                max: new Date(),
                message: "Date is Not Valid",
            }
        ]
    })

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

})