(function () {
    'use strict';
    $(document).ready(function () {
        $(function () {
            $("#lista").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        dataType: "json",
                        data:
                        {
                            produtos: request.term,
                        },
                        type: 'Get',
                        url: "Produtos/BuscarProdutos",
                        success: function (data) {
                            response(data);
                            $("#txtIdProcedimento").val("");
                        },
                        error: function (data) {
                            console.log(data);
                        }
                    });
                },
                select: function (event, ui) {
                    event.preventDefault();
                    $(this).val(ui.item.label);
                    $("#txtIdProcedimento").val(ui.item.id);
                }
            });
        });
        $(function () {
            $("#local").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        dataType: "json",
                        data:
                        {
                            localidades: request.term,
                            produtos: $("#lista").val(),
                        },
                        type: 'Get',
                        url: "Produtos/BuscarLocalidades",
                        success: function (data) {
                            response(data);
                        },
                        error: function (data) {
                            console.log(data);
                        }
                    });
                }
            });
        });
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
            ]
        });
    });

    function AlertaMensagem() {
        $("#ModalCentralizado").modal();
    }


})();


