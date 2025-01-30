$(document).ready(function () {
     // Custom method to check only alphabets without spaces
     $.validator.addMethod("alphaOnly", function(value, element) {
        return this.optional(element) || /^[A-Za-z]+$/.test(value);
    }, "space and number are not allowd ");

    // custom password validation method 
    $.validator.addMethod("noSpaceInPassword",function(value,element){
        return this.optional(element) || !/\s/.test(value);
    },"space not allowd in password")
    // Validate the registration form
    $('#registerFormSubmit').validate({
        rules: {
            firstName: {
                required: true,
                minlength: 4,
                alphaOnly:true
                
            },
            lastName: {
                required: true,
                minlength: 4,
                alphaOnly:true
               
            },
            email: {
                required: true,
                email: true,              
            },
            password: {
                required: true,
                minlength: 8,
                maxlength: 16,
                noSpaceInPassword:true
            },
            confirmPassword: {
                required: true,
                minlength: 8,
                maxlength: 16,
                equalTo: "#password" // it iis use to password and confirm password matching
            }
        },
        messages: {
            firstName: {
                required: "Please enter your first name.",
                minlength: "First name must be at least 4  characters long.",
                alphaOnly: " spaces , specialcharcter and numbers are not allowd"
            },
            lastName: {
                required: "Please enter your last name.",
                minlength: "Last name must be at least 4 characters long.",
                alphaOnly: " spaces or numbers are not allowd"
               
            },
            email: {
                required: "Please enter your email address.",
                email: "Please enter a valid email address.",
              
            },
            password: {
                required: "Please enter a password.",
                minlength: "Password must be at least 8 characters long.",
                maxlength: "Password must be no more than 16 characters long.",
                noSpacesInPassword: "space not allowd in password."
               
            },
            confirmPassword: {
                required: "Please confirm your password.",
                minlength: "Password confirmation must be at least 8 characters long.",
                maxlength: "Password confirmation must be no more than 16 characters long.",
                equalTo: "Passwords do not match."
            }
        },
        submitHandler: function (form) {
            // get values from users
            const firstName = $('#firstName').val().trim();
            const lastName = $('#lastName').val().trim();
            const email = $('#email').val().trim();
            const password = $('#password').val().trim();
            //const confirmPassword = $('#confirmPassword').val();

            // check user is exists or not 
            const existingUser = localStorage.getItem('user_' + email);
            if (existingUser) {
                alert("User already exists with this email.");
                return;
            }

            // object new user
            const newUser = {
                firstName: firstName,
                lastName: lastName,
                email: email,
                password: password
            };
            // if i have not write code for new user and directly  add after stringfy method

            // save data to local storage
            localStorage.setItem('user_' + email, JSON.stringify(newUser));

            // Redirect to login page after successful registration
            alert("Registration successful. Please login.");
            // two method learn
            // window.location.href = 'login.html';
            // self is use to current window load
            window.open("login.html", "_self"); 
            // function redirectTo(url) {
            //     window.location.href = url;
            // }
            // redirectTo("login.html");
            
        }
    });
    // validate registration form end
});
