// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var firstname = document.getElementsByClassName('firstname')[0];
var lastname = document.getElementsByClassName('lastname')[0];
var loginName = document.getElementsByClassName('logname')[0];
var passwordC = document.getElementsByClassName('pass')[0];
var confirmpassword = document.getElementsByClassName('passwordType')[0];

var firstname_error = document.getElementById('error-firstname');
var lastname_error = document.getElementById('error-lastname');
var loginName_error = document.getElementById('error-loginName');
var password_error = document.getElementById('error-password');
var passwordType_error = document.getElementById('error-passwordType');

function validated() {
    var pattern = new RegExp("^(((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9])(?=.*[A-Z]))|((?=.*[A-Z])(?=.*[0-9])(?=.*[a-z])))(?=.{6,})");

    if (firstname.value.length < 3) {
        firstname_error.style.display = "block";
        return false;

    }

    if (lastname.value.length < 3) {
        lastname_error.style.display = "block";
        return false;

    }

    if (loginName.value.length < 3) {
        loginName_error.style.display = "block";
        return false;

    }

    if (!pattern.test(passwordC.value)) {
        password_error.style.display = "block";
        return false;
    }

    if (confirmpassword.value !== passwordC.value) {
        passwordType_error.style.display = "block";
        return false;
    }

    return true;
}

function username_verify() {
    if (loginName.value.length >= 5) {
        loginName_error.style.display = "none";
        return true;
    }
    return false;
}

function firstname_verify() {
    if (firstname.value.length >= 3) {
        firstname_error.style.display = "none";
        return true;
    }
    return false;
}

function lastname_verify() {
    if (lastname.value.length >= 3) {
        lastname_error.style.display = "none";
        return true;
    }
    return false;
}

function password_verify() {
    var pattern = new RegExp("^(((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9])(?=.*[A-Z]))|((?=.*[A-Z])(?=.*[0-9])(?=.*[a-z])))(?=.{6,})");

    if (pattern.test(passwordC.value)) {
        password_error.style.display = "none";
        return true;
    }
    
    return false;
}


function passwordMatch_verify() {
    if (passwordC.value === confirmpassword.value) {
        passwordType_error.style.display = "none";
        return true;
    }
    return false;
}

firstname.addEventListener('textInput', firstname_verify);
lastname.addEventListener('textInput', lastname_verify);
loginName.addEventListener('textInput', username_verify);
passwordC.addEventListener('textInput', password_verify);
confirmpassword.addEventListener('textInput', passwordMatch_verify);