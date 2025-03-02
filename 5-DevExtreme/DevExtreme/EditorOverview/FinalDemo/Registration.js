

$(document).ready(function () {
    
    
    // Name Field with validation
    $("#R01F02").dxTextBox({
        placeholder: "Enter your name"
    }).dxValidator({
        validationRules: [{ type: "required", message: "Name is required" }]
    });

    // Email Field with validation
    $("#R01F03").dxTextBox({
        placeholder: "Enter your email"
    }).dxValidator({
        validationRules: [
            { type: "required", message: "Email is required" },
            { type: "email", message: "Enter a valid email" }
        ]
    });

    // Password Field with validation
    $("#R01F04").dxTextBox({
        placeholder: "Enter your password",
        mode: "password"
    }).dxValidator({
        validationRules: [
            { type: "required", message: "Password is required" },
            { type: "stringLength", min: 6, message: "Password must be at least 6 characters" }
        ]
    });

    // Phone Field with validation
    $("#R01F05").dxTextBox({
        placeholder: "Enter your phone"
    }).dxValidator({
        validationRules: [
            { type: "required", message: "Phone number is required" },
            { type: "pattern", pattern: "^[0-9]{10}$", message: "Enter a valid 10-digit phone number" }
        ]
    });

    // Address Field with validation
    $("#R01F06").dxTextArea({
        placeholder: "Enter your address",
        height: 70
    }).dxValidator({
        validationRules: [{ type: "required", message: "Address is required" }]
    });

    // Role SelectBox with validation
    $("#R01F07").dxSelectBox({
        items: [
            { id: 0, text: "Admin" },
            { id: 1, text: "User" }
        ],
        valueExpr: "id",
        displayExpr: "text",
        value: 1  // Default User
    }).dxValidator({
        validationRules: [{ type: "required", message: "Role selection is required" }]
    });

    // Register Button
    $("#register-btn").dxButton({
        text: "Register",
        type: "success",
        onClick: function () {
            // **Check if all fields are valid**
            let isValid = true;
            $(".dx-validator").each(function () {
                let validator = $(this).dxValidator("instance");
                let result = validator.validate();
                if (!result.isValid) {
                    isValid = false;
                }
            });

            // **If not valid, stop execution**
            if (!isValid) {
                DevExpress.ui.notify("Please fill all fields correctly!", "error", 4000);
                return;
            }
            let requestData = {
                R01F02: $("#R01F02").dxTextBox("instance").option("value"),
                R01F03: $("#R01F03").dxTextBox("instance").option("value"),
                R01F04: $("#R01F04").dxTextBox("instance").option("value"),
                R01F05: $("#R01F05").dxTextBox("instance").option("value"),
                R01F06: $("#R01F06").dxTextArea("instance").option("value"),
                R01F07: $("#R01F07").dxSelectBox("instance").option("value")
            };

            $.ajax({
                url: "http://localhost:5021/api/CLUSR01/addUser",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(requestData),
                success: function (response) {
                    DevExpress.ui.notify("User Registered Successfully!", "success", 3000);
                    console.log("response", response);
                    setTimeout(function () {
                        window.location.href = "Login.html"; // Redirect to login page
                    }, 2000);
                },
                error: function (err) {
                    DevExpress.ui.notify("Error: " + err.responseText, "error", 2000);
                }
            });
        }
    });
});
