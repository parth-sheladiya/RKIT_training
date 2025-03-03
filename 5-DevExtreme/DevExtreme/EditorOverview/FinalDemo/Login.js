$(document).ready(function () {
    function parseJwt(token) {
        var base64Url = token.split('.')[1]; // JWT token ka payload extract karo
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/'); // Base64 formatting fix
        var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
        return JSON.parse(jsonPayload); // JSON object return karega
    }

    $("#UserName").dxTextBox({
       // text:"user name",
        placeholder: "Enter your username",
        value: "",
    }).dxValidator({
        validationRules: [
            { 
                type: "required", 
                message: "Username is required" 
            }
        ],
    })

    $("#Password").dxTextBox({
       // text:"password",
        placeholder: "Enter your password",
        value: "",
        mode: "password",
    }).dxValidator({
        validationRules: [
            { 
                type: "required", 
                message: "Password is required" 
            }
        ],
    })
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
            const result = DevExpress.validationEngine.validateGroup();
            if(result.isValid){
                
            }
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
                        localStorage.setItem("Token",response.data);
                        let decodedToken = parseJwt(response.data); //JWT decode karo
                        console.log("Decoded Token:", decodedToken); // Console me dekho decoded data kya hai

                        let role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || "User";
                        console.log("User Role:", role); // Role check karo

                        DevExpress.ui.notify("User Logged In Successfully!", "success", 2000);

                        setTimeout(function () {
                            if (role === "Admin") {
                                window.location.href = "AdminDash.html"; // Admin ke liye
                            } else {
                                window.location.href = "UserDash.html";  // Normal user ke liye
                            }
                        }, 2000);
                    } else {
                        DevExpress.ui.notify("errrr please try again", "error", 2000);
                    }
                },
                error: function (err) {
                    let errorMessage = "Invalid Username or Password!";

                    if (err.responseJSON && err.responseJSON.message) {
                        errorMessage = err.responseJSON.message;
                    }

                    DevExpress.ui.notify(errorMessage, "error", 2000);
                }
            });
        }
    
    });
})