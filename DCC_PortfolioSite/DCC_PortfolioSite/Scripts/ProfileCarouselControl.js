$(document).ready(function(){
    console.log("TEST");
    $('.ProfileCarousel').slick({
        accessibility: true,
        arrows: true,
        dots: true,
        infinite: true,
        speed:300,
        slidesToShow:1,
        slidesToScroll:1
 
        // You can unslick at a given breakpoint now by adding:
        // settings: "unslick"
        // instead of a settings object

        });
});