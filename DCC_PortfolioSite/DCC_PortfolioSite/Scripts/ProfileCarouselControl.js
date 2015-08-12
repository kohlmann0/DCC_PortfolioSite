$(document).ready(function(){
    $('.ProfileCarousel').slick({
        //accessibility: true,
        //arrows: true,
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


$(document).ready(
    $('#ProfileButton').click(function () {
        console.log(1)
        $('.ProfileCarousel').slick('slickGoTo', 0);
    }));

$(document).ready(
    $('#ProjectButton').click(function () {
    console.log(2)
    $('.ProfileCarousel').slick('slickGoTo', 1);
    }));

$(document).ready(
    $('#ResumeButton').click(function () {
    console.log(3)
    $('.ProfileCarousel').slick('slickGoTo', 2);
    }));

