$(document).ready(function () {
    $('.SearchResultsCarousel').slick({
        //accessibility: true,
        //arrows: true,
        centerMode: true,
        centerPadding: '5%',
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 1

        // You can unslick at a given breakpoint now by adding:
        // settings: "unslick"
        // instead of a settings object

    });
});