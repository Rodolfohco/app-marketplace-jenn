(function () {
    'use strict';

    $(document).ready(function () {
        $('.slider').slick({
            slidesToShow: 3,
            slidesToScroll: 1,

            responsive: [
                {
                    breakpoint: 1500,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                        infinite: false,

                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 2
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
                // You can unslick at a given breakpoint now by adding:
                // settings: "unslick"
                // instead of a settings object
            ]
        });

        //Menu button on click event
        $('.mobile-nav-button').on('click', function () {
            // Toggles a class on the menu button to transform the burger menu into a cross
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(1)").toggleClass("mobile-nav-button__line--1");
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(2)").toggleClass("mobile-nav-button__line--2");
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(3)").toggleClass("mobile-nav-button__line--3");

            // Toggles a class that slides the menu into view on the screen
            $('.mobile-menu').toggleClass('mobile-menu--open');
            return false;
        });

        $(function () {
            var listas = [
                "Exame 1",
                "Exame 2",
                "Exame 3",
                "Exame 5"
            ];
            $("#lista").autocomplete({
                source: listas
            });
        });

        $(function () {
            var locais = [
                "local 1",
                "local 2",
                "local 3",
                "local 5"
            ];
            $("#local").autocomplete({
                source: locais
            });
        });


        $('select').multipleSelect({
            selectAll: false,
            displayTitle: false,
            filter: true,
            animate: 'fade'
        });


        $('.slider-time').slick({
            slidesToShow: 5,
            slidesToScroll: 1,

            responsive: [
                {
                    breakpoint: 1500,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                        infinite: false,

                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 2
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
                // You can unslick at a given breakpoint now by adding:
                // settings: "unslick"
                // instead of a settings object
            ]
        });

        $(' .item-select').on('click', function () {
            $(this).parent('.col-select').find('.content-select').toggleClass("ativo"); //you can list several class names 

        });

        $('.btn-convenio').on('click', function (e) {
            e.preventDefault();
            $(this).toggleClass("btn-ativo"); //you can list several class names 
            $(this).parent('.btn-content').find('.box-convenios').toggleClass("box-ativo");

        });

    });

})();
