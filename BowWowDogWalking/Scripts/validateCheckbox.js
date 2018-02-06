$('.submit').click(function () {
    console.log("click");
    if ($('#SixtyMin').is(":checked") || $('#ThirtyMin').is(":checked")) {
        return true;
    }

    else {
        document.getElementById("error-message").innerHTML = "Please make a selection";
        return false;
    }

});

