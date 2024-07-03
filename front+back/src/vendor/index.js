$(document).ready(function () {
    // Конфигурация первой карусели
    $('.carousel').slick({
        centerMode: true,
        slidesToShow: 1,
        dots: true,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 5000,
        speed: 1000,
        variableWidth: false,
        responsive: [{
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    slidesToShow: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    slidesToShow: 1
                }
            }
        ]
    });

    // Конфигурация второй карусели
    $('.carousel2').slick({
        slidesToShow: 4, // Показывать 4 слайда одновременно
        slidesToScroll: 4, // Прокручивать по 4 слайда
        dots: false, // Отключаем точки
        arrows: false,
        autoplay: false, // Отключаем автопрокрутку
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2
            }
        }]
    });

    $('.carousel3').slick({
        centerMode: true,
        slidesToShow: 1,
        dots: true,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 3000,
        speed: 1000,
        variableWidth: false,
        asNavFor: '.caption-carousel',
        responsive: [{
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    slidesToShow: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    
    $('.caption-carousel').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        asNavFor: '.carousel3', // Связываем слайдер с подписями с основным слайдером
        dots: false,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 4000, // Увеличиваем скорость автопрокрутки для подписей
        focusOnSelect: true
    });
    // Обработка нажатия на кнопки для первой карусели
    $('.prev-button').click(function () {
        $('.carousel').slick('slickPrev');
    });

    $('.next-button').click(function () {
        $('.carousel').slick('slickNext');
    });

    // Обработка нажатия на кнопки для второй карусели
    $('.carousel2-prev-button').click(function () {
        $('.carousel2').slick('slickPrev');
    });

    $('.carousel2-next-button').click(function () {
        $('.carousel2').slick('slickNext');
    });
    // Обработка нажатия на кнопки для 3 карусели

    $('.carousel3-prev-button').click(function () {
        $('.carousel3').slick('slickPrev');
    });

    $('.carousel3-next-button').click(function () {
        $('.carousel3').slick('slickNext');
    });

    // Обновляем кнопки при изменении слайда во второй карусели
    $('.carousel2').on('afterChange', function (event, slick, currentSlide) {
        updateButtons();
    });

    function updateButtons() {
        var currentSlideIndex = $('.carousel2').slick('slickCurrentSlide');
        var slidesToShow = $('.carousel2').slick('slickGetOption', 'slidesToShow');
        var slideCount = $('.carousel2 .slick-slide').length;

       
    }
    
document.getElementById("open-modal-btn").addEventListener("click", function() {
    document.getElementById("my-modal").classList.add("open")
})
document.getElementById("open-modal-btn2").addEventListener("click", function() {
    document.getElementById("my-modal").classList.add("open")
})

document.getElementById("close-my-modal-btn").addEventListener("click", function() {
    document.getElementById("my-modal").classList.remove("open")
})

window.addEventListener('keydown', (e) => {
    if (e.key === "Escape") {
        document.getElementById("my-modal").classList.remove("open")
    }
});

document.querySelector("#my-modal .modal__box").addEventListener('click', event => {
    event._isClickWithInModal = true;
});
document.getElementById("my-modal").addEventListener('click', event => {
    if (event._isClickWithInModal) return;
    event.currentTarget.classList.remove('open');
});




document.querySelector(".change-btn").addEventListener("click", function() {
    document.getElementById("my-modal-change").classList.add("open");
    document.getElementById("my-modal").classList.remove("open")
});

document.getElementById("close-my-modal-btn-change").addEventListener("click", function() {
    document.getElementById("my-modal-change").classList.remove("open")
});

window.addEventListener('keydown', (e) => {
    if (e.key === "Escape") {
        document.getElementById("my-modal-change").classList.remove("open")
    }
});

document.querySelector("#my-modal-change .modal__box").addEventListener('click', event => {
    event._isClickWithInModal = true;
});

document.getElementById("my-modal-change").addEventListener('click', event => {
    if (event._isClickWithInModal) return;
    event.currentTarget.classList.remove('open');
});

});