(function () {
    $(document).ready(function () {
        $('.mobile-nav-button').on('click', function () {
            // Toggles a class on the menu button to transform the burger menu into a cross
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(1)").toggleClass("mobile-nav-button__line--1");
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(2)").toggleClass("mobile-nav-button__line--2");
            $(".mobile-nav-button .mobile-nav-button__line:nth-of-type(3)").toggleClass("mobile-nav-button__line--3");
            $('.mobile-menu').toggleClass('mobile-menu--open');
            return false;
        });
        $(".item-select").click(function () {
            var elements = $(".item-select")
            for (var i = 0; i < elements.length; i++) {
                if (elements[i] != this)
                    $(elements[i]).parent(".col-select").find(".content-select").removeClass("ativo");
            }
        });
        $('select').multipleSelect({
            selectAll: false,
            displayTitle: false,
            filter: true,
            animate: 'fade'
        });
        $('.item-select').on('click', function () {
            $(this).parent('.col-select').find('.content-select').toggleClass("ativo"); //you can list several class names 

        });
        $('.btn-convenio').on('click', function (e) {
            e.preventDefault();
            $(this).toggleClass("btn-ativo"); //you can list several class names 
            $(this).parent('.btn-content').find('.box-convenios').toggleClass("box-ativo");

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
            ]
        });
        onload();
    });
    function onload() {
        var url = window.location.search.replace("?", "");
        var items = url.split("&");

        if (items) {
            for (var i = 0; i < items.length; i++) {

                var campo = items[i].substring(0, items[i].indexOf('['))
                var valor = items[i].substring(items[i].indexOf("="), items[i].length).replace("=", "");
                valor = valor.replace("%20", "").replace("%20", "").replace("%20", "").replace("%20", "");
                valor = valor.replace("%C3%A3", "").replace("%C3%A3", "").replace("%C3%A3", "").replace("%C3%A3", "").replace("%C3%A3", "");
                valor = valor.replace("%C3%A9", "").replace("%C3%A9", "").replace("%C3%A9", "").replace("%C3%A9", "").replace("%C3%A9", "");

                if ($("[data-" + campo + "-encode='" + valor + "']").length > 0) {
                    $($("[data-" + campo + "-encode='" + valor + "']")[0]).click();
                }
            }
        }
        $("#botaofiltrartodos").on('click', function () {

            var elementos = $("#todosfiltros input.form-check-input:checked");
            var parametros = "";
            for (var i = 0; i < elementos.length; i++) {
                var param = $(elementos[i]).attr("data-controller");
                var valor = $(elementos[i]).attr("data-" + param);
                if (i > 0)
                    parametros += "&";
                var array = parametros.split(param + "[");
                if (parametros.indexOf(param + "[") == -1)
                    array = [];
                parametros += param + "[" + array.length + "]=" + valor;
            }


            var id = $("#idProcedimento").val();
            window.location.href = "/Produtos/ListarPorFiltros?idProcedimento=" + id + "&"  + parametros;
        });



        $("#todosfiltros .botoesfiltro").remove();

    }
})();