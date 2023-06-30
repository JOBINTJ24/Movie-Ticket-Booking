
/// validation in movie name///

function formvalidate() {

    var movie_name = document.getElementById("movie name").value.trim();

    if (movie_name == "") {
        document.getElementById('error_name').style.display = "block";

        document.getElementById('error_name').innerHTML = "**Please enter movie name";
        return false;
    }
    else {
        document.getElementById('error_name').style.display = "none";
        return true;

    }
}

/// validation in movie description ///

function formvalidatelname() {
    var movie_description = document.getElementById("movie description").value;
    if (movie_description == "") {
        document.getElementById('error_description').style.display = "block";

        document.getElementById('error_description').innerHTML = "**Please enter  movie description";
        return false;
    }
    else {
        document.getElementById('error_description').style.display = "none";
        return true;
    }
}

/// validation in movie image ///

function formvalidateemail() {
    var movie_image = document.getElementById("movie image").value;
    if (movie_image == "") {
        document.getElementById('error_image').style.display = "block";

        document.getElementById('error_image').innerHTML = "**Please add movie image";
        return false;
    }
    else {
        document.getElementById('error_image').style.display = "none";
        return true;
    }
}

/// validation in movie streaming date ///

function formvalidatehname() {
    var movie_date = document.getElementById('streaming date').value.trim();
    if (movie_date == "") {
        document.getElementById('error_date').style.display = "block";
        document.getElementById('error_date').innerHTML = "**Please ennter streaming date";
        return false;
    } else {
        document.getElementById('error_date').style.display = "none";
        return true;
    }
}

/// validation in movie genre ///

function formvalidatestrename() {
    var movie_genre = document.getElementById('movie genre').value.trim();
    if (movie_genre == "") {
        document.getElementById('error_genre').style.display = "block";
        document.getElementById('error_genre').innerHTML = "**Please enter genre";
        return false;
    } else {
        document.getElementById('error_genre').style.display = "none";
        return true;
    }
}

/// validation in movie duration ///

function formvalidatecity() {
    var movie_duration = document.getElementById('movie duration').value.trim();
    if (movie_duration == "") {
        document.getElementById('error_duration').style.display = "block";
        document.getElementById('error_duration').innerHTML = "**Please enter duration";
        return false;
    } else {
        document.getElementById('error_duration').style.display = "none";
        return true;
    }
}

/// validation in movie language ///


function formvalidateuser() {
    var movie_language = document.getElementById("movie language").value.trim();

    if (movie_language == "") {
        document.getElementById('error_language').style.display = "block";

        document.getElementById('error_language').innerHTML = "**Please enter language";
        return false;
    }

    else {
        document.getElementById('error_language').style.display = "none";
        return true;

    }
}

