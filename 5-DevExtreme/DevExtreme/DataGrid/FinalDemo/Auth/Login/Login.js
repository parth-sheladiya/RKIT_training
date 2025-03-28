﻿import {DisplayNotifyMessage} from "../../services/utils.js";

$(document).ready(function () {
    $("#login-form").dxForm({
        formData: {
            R01F02: "",
            R01F04: ""
        },
        items: [
            { dataField: "R01F02", label: { text: "Username" }, editorType: "dxTextBox" },
            { dataField: "R01F04", label: { text: "Password" }, editorType: "dxTextBox", editorOptions: { mode: "password" } }
        ]
    });

    $("#login-btn").dxButton({
        text: "Login",
        type: "success",

        onClick: function () {
            let formData = $("#login-form").dxForm("instance").option("formData");
            let requestData = {
                R01F02: formData.R01F02,
                R01F04: formData.R01F04
            };

            $.ajax({
                url: "http://localhost:5021/api/CLAuth/Login",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(requestData),
                success: function (response) {
                    console.log("API Response:", response);

                    if (!response.isError && response.data) {
                        localStorage.setItem("Token", response.data.token);
                        let token = response.data.token;
                                        let role = response.data.role;

                                        console.log("Token:", token);
                                        console.log("Role:", role);


                                       
                                        localStorage.setItem("role", role);
                        

                       

                                        DisplayNotifyMessage("User Logged In Successfully!", "success", 2000);

                        setTimeout(function () {
                            if (role === "Admin") {
                                window.location.href = "../../AdminPart/AdminDash.html";
                            } else {
                                window.location.href = "../../UserPart/UserDash.html";
                            }
                        }, 1000);
                    } else {
                        DisplayNotifyMessage("Error: Please try again.", "error", 2000);
                    }
                },
                error: function (err) {
             

                    DisplayNotifyMessage("invalid user name or password", "error", 2000);
                }
            });
        }
    });
});

