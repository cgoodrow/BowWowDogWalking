
$("a").click(function () {
    var location = $(this).attr("href");
    console.log(location);
    $('html, body').animate({
        scrollTop: $(location).offset().top
    }, 2000);
    $('.navbar-collapse.in').collapse('hide');
});