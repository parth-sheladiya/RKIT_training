$(document).ready(function () {
    // Validate the login form
    $('#loginFormSubmit').validate({
        rules: {
            loginEmail: {
                required: true,
                email: true // simple email validation check
            },
            loginPassword: {
                required: true,
                minlength: 8
            }
        },
        messages: {
            loginEmail: {
                required: "Please enter your email address.",
                email: "Please enter a valid email address."
            },
            loginPassword: {
                required: "Please enter your password.",
                minlength: "Password must be at least 8 characters long."
            }
        },
        submitHandler: function (form) {
            const email = $('#loginEmail').val();
            const password = $('#loginPassword').val();

            const userData = localStorage.getItem('user_' + email);

            if (userData) {
                const user = JSON.parse(userData);

                if (user.password === password) {
                    // store email of login user
                    localStorage.setItem('loggedInEmail', email);

                    // redirect to index page
                    window.location.href = 'index.htm';
                    // reuse code 
                    // redirectTo("index.htm")
                } else {
                    alert("Incorrect password. Please try again.");
                }
            } else {
                alert("No account found with this email. Please register.");
            }
        }
    });
});
