function formvalidate() {

    var a = document.getElementById("nme").value.trim();

    var p = /^[a-zA-Z^\s]+$/;
    if (a == "") {
        document.getElementById('fns').style.display = "block";

        document.getElementById('fns').innerHTML = "**Please Enter  first Name";
        return false;
    }

    if (/[^a-zA-Z^\s]/.test(a)) {
        document.getElementById('fns').style.display = "block";
        document.getElementById('fns').innerHTML = "**Only alphabets allowed";
        return false;
    }
    else {
        document.getElementById('fns').style.display = "none";
        return true;

    }
}


function formvalidatelname() {
    var b = document.getElementById("lnme").value;
    if (b == "") {
        document.getElementById('kn').style.display = "block";

        document.getElementById('kn').innerHTML = "**Please enter  last name";
        return false;
    }
    if (/[^a-zA-Z^\s]/.test(b)) {
        document.getElementById('kn').style.display = "block";
        document.getElementById('kn').innerHTML = "**Only alphabets allowed";
        return false;
    }
    else {
        document.getElementById('kn').style.display = "none";
        return true;
    }
}
function formvalidateldob() {

    var inputDate = new Date(document.getElementById("dob").value); // get the input date value
    var currentDate = new Date();
    var minDate = new Date(currentDate.getFullYear() - 1, currentDate.getMonth(), currentDate.getDate());
    var errorSpan = document.getElementById("dd"); // get the error span element

    if (document.getElementById("dob").value === "") { // check if the input date is empty
        errorSpan.innerHTML = "Please select a date";
        errorSpan.style.display = "block";
        return false;
    } else if (inputDate > minDate) { // check if the input date is not in the future
        errorSpan.innerHTML = "Please enter a date in the past";
        errorSpan.style.display = "block";
        return false;
    } else {
        errorSpan.innerHTML = ""; // clear the error message if the date is valid
        errorSpan.style.display = "none";
        return true;

    }
}
function formvalidatephone() {


    var phq = document.getElementById("phl").value;
    var exprs = /^[6-9]\d{9}$/;
    if (phq == "") {
        document.getElementById('pp').style.display = "block";

        document.getElementById('pp').innerHTML = "**Please enter  phone";
        return false;
    }
    if (phq != "" && exprs.test(phq) == false) {
        document.getElementById('pp').style.display = "block";
        document.getElementById('pp').innerHTML = "Invalid phone number";
        return false;
    }
    else {
        document.getElementById('pp').style.display = "none";
        return true;

    }

}
function formvalidateemail() {
    var aa = document.getElementById("eemail").value;
    var stt = /^[\w\+\'\.-]+@[\w\'\.-]+\.[a-zA-Z]{2,}$/;
    if (aa == "") {
        document.getElementById('ela').style.display = "block";

        document.getElementById('ela').innerHTML = "**Please enter  email";
        return false;
    }
    if (aa != "" && stt.test(aa) == false) {

        document.getElementById('ela').style.display = "block";
        document.getElementById('ela').innerHTML = "Invalid email id";
        return false;
    }
    else {
        document.getElementById('ela').style.display = "none";
        return true;
    }
}
function formvalidatehname() {
    var ee = document.getElementById('hnamee').value.trim();
    if (ee == "") {
        document.getElementById('hho').style.display = "block";
        document.getElementById('hho').innerHTML = "**Please enter address";
        return false;
    } else {
        document.getElementById('hho').style.display = "none";
        return true;
    }
}
function formvalidatestrename() {
    var ff = document.getElementById('strename').value.trim();
    if (ff == "") {
        document.getElementById('sss').style.display = "block";
        document.getElementById('sss').innerHTML = "**Please Enter state";
        return false;
    } else {
        document.getElementById('sss').style.display = "none";
        return true;
    }
}
function formvalidatecity() {
    var gg = document.getElementById('cityname').value.trim();
    if (gg == "") {
        document.getElementById('kkk').style.display = "block";
        document.getElementById('kkk').innerHTML = "**Please Enter city name";
        return false;
    } else {
        document.getElementById('kkk').style.display = "none";
        return true;
    }
}



function formvalidateuser() {
    var ab = document.getElementById("usenamee").value.trim();

    var yb = /^[a-zA-Z^\s]+$/;
    if (ab == "") {
        document.getElementById('skyy').style.display = "block";

        document.getElementById('skyy').innerHTML = "**Please enter user name";
        return false;
    }

    if (/[^a-zA-Z^\s]/.test(ab)) {
        document.getElementById('skyy').style.display = "block";
        document.getElementById('skyy').innerHTML = "**Only alphabets allowed";
        return false;
    }
    else {
        document.getElementById('skyy').style.display = "none";
        return true;

    }
}
function formvalidatepasd() {
    var ggg = document.getElementById('pcode').value.trim();
    if (ggg == "") {
        document.getElementById('mmm').style.display = "block";
        document.getElementById('mmm').innerHTML = "**Please enter password";
        return false;
    }
  
    else {
        document.getElementById('mmm').style.display = "none";
        return true;
    }
}

function formvalidatecpasd() {
    var ee = document.getElementById('cpassword').value.trim();

    if (ggg != ee) {
        document.getElementById('cpss').style.display = "block";

        document.getElementById('cpss').innerHTML = "**Incorrect password";
        return false;
    }
    else {
        document.getElementById('cpss').style.display = "none";
        return true;
    }
}

function openLForm() {

    document.getElementById("popupLForm").style.display = "block";

}
function closeLForm() {
    document.getElementById("popupLForm").style.display = "none";
}


function populateDistricts() {
    var stateDropdown = document.getElementById("state");
    var districtDropdown = document.getElementById("district");

    districtDropdown.innerHTML = '<option value="">Select District</option>';

    var selectedState = stateDropdown.value;

    if (selectedState === "Kerala") {
        districtDropdown.innerHTML += '<option value="kasargod">kasargod</option><option value="Wayanad">Wayanad</option><option value="Kozhikode">Kozhikode</option><option value="Kottayam">Kottayam</option><option value="Palakad">Palakad</option>';
    } else if (selectedState === "Hyderabad") {
        districtDropdown.innerHTML += '<option value="manikoda">Manikoda</option><option value="meerpet">Meerpet</option><option value="madhapur">Madhapur</option>';
    } else if (selectedState === "Karnadaka") {
        districtDropdown.innerHTML += '<option value="Bangalore">Bangalore</option><option value="Mysore">Mysore</option><option value="Hubli">Hubli</option><option value="Mangalore">Mangalore</option>';
    }
}
