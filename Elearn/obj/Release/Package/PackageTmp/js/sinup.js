document.getElementById("Pass").setAttribute("type", "password");
document.getElementById("send").disabled = true;
function validation(fname,lname,phone,username,pass,repass) {

    if (validatext(fname) == false) {

        document.getElementById("send").disabled = true;
        console.log("First name is empty");
        return "First name is empty";
    }
    if (validatext(lname) == false) {
        document.getElementById("send").disabled = true;
        console.log("Last name is empty");
        return "Last name is empty";
    }
    if (validatext(phone) == false) {
        document.getElementById("send").disabled = true;
        console.log("Phone is empty");
        return "Phone is empty";
    }
    if (validatext(username) == false) {
        document.getElementById("send").disabled = true;
        console.log("UserName is empty");
        return "UserName is empty";
    }
    if (validatext(pass) == false) {
        document.getElementById("send").disabled = true;
        console.log("Password is empty");
        return "Password is empty";
    }
    if (validatext(repass) == false) {
        document.getElementById("send").disabled = true;
        console.log("Repassword is empty");
        return "Repassword is empty";
    }
    if (validaphone(phone) == false) {
        document.getElementById("send").disabled = true;
        return "not phone number";
    }
    if (validapass(pass, repass) == false) {
        document.getElementById("send").disabled = true;
        console.log("pass not equal repass")
        return "pass not equal repass";
    }
    document.getElementById("send").disabled = false;
    console.log("fildes is valid");
    return "fildes is valid";
}
function validaphone(phone){
    var inputtxt = document.getElementById(phone).value;
    var num = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    var arr = inputtxt.split("");
    for (var i = 0; i < arr.length; i++) {
        if (num.includes(parseInt(arr[i])) == false) {
            console.log(false);
            return false;
        }
    }
    console.log(true);
    return true;
}
function validatext(id) {
    var x = document.getElementById(id).value;
    if (x == "") {
        return false;
    }
    return true;
}
function validapass(pass, repass) {
    var p = document.getElementById(pass).value;
    var rep = document.getElementById(repass).value;
    if (p == rep) {
        return true;
    }
    return false;
}

document.getElementById("validation").addEventListener("click", function () {
    document.getElementById("m").innerText =validation("Fname","Lname","phone","UserName","Pass","Repass");
    
});