$(document).ready(function () {
    $("#registration-form").dxForm({
        formData: {
            R01F02: "",
            R01F03: "",
            R01F04: "",
            R01F05: "",
            R01F06: "",
            R01F07: 1  // Default User (1)
        },
        items: [
            { dataField: "R01F02", label: { text: "Name" }, editorType: "dxTextBox" },
            { dataField: "R01F03", label: { text: "Email" }, editorType: "dxTextBox" },
            { dataField: "R01F04", label: { text: "Password" }, editorType: "dxTextBox", editorOptions: { mode: "password" } },
            { dataField: "R01F05", label: { text: "Phone" }, editorType: "dxTextBox" },
            { dataField: "R01F06", label: { text: "Address" }, editorType: "dxTextBox" },
            {
                dataField: "R01F07",
                label: { text: "Role" },
                editorType: "dxSelectBox",
                editorOptions: {
                    items: [
                        { id: 0, text: "Admin" },
                        { id: 1, text: "User" }
                    ],
                    valueExpr: "id",
                    displayExpr: "text",
                    value: 1
                }
            }
        ]
    });

    $("#register-btn").dxButton({
        text: "Register",
        type: "success",
        onClick: function () {
            let formData = $("#registration-form").dxForm("instance").option("formData");

            let requestData = {
                R01F01: formData.R01F01,  // Primary User ID
                R01F02: formData.R01F02,
                R01F03: formData.R01F03,
                R01F04: formData.R01F04,
                R01F05: formData.R01F05,
                R01F06: formData.R01F06,
                R01F07: formData.R01F07
            };

            $.ajax({
                url: "http://localhost:5021/api/CLUSR01/addUser",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(requestData),
                success: function (response) {
                    DevExpress.ui.notify("User Registered Successfully!", "success", 2000);
                    console.log("response", response);
                    setTimeout(function () {
                        window.location.href = "Login.html";  // Login page ka correct URL yahan daalein
                    }, 2000);
                },
                error: function (err) {
                    DevExpress.ui.notify("Error: " + err.responseText, "error", 2000);
                }
            });
        }
    });

});
