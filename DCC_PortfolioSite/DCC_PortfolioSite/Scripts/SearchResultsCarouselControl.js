$(document).ready(function () {
    $('.SearchResultsCarousel').slick({
        accessibility: true,
        arrows: true,
        centerMode: true,
        centerPadding: '5%',
        dots: true,
        infinite: true,
        mobileFirst: true,
        speed: 300,
        slidesToShow: 1,
        slidesToScroll: 1,
        swipeToSlide: true,
        responsive: [
            {
                breakpoint: 480,
                settings: {
                    accessibility: true,
                    arrows: true,
                    centerMode: true,
                    centerPadding: '5%',
                    dots: true,
                    infinite: true,
                    mobileFirst: true,
                    speed: 300,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    swipeToSlide: true,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    accessibility: true,
                    arrows: true,
                    centerMode: true,
                    centerPadding: '5%',
                    dots: true,
                    infinite: true,
                    mobileFirst: true,
                    speed: 300,
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    swipeToSlide: true,
                }
            }
        ]

    });
});