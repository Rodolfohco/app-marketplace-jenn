function buscarBairros() {
    var count = $("[class*='checkbairro_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;

    var contador = $("[class*='checkbairro_']:checked").length;

    if (contador > 0)
        contador = (contador / 2) - 1;

    $("[class*='checkbairro_']:checked").each(function () {

        if (i <= contador) {
            model.push($(this).attr("data-bairro"));

            if (i > 0)
                param += "&";

            param += "bairro[" + i + "]=" + $(this).attr("data-bairro");
        }
        i++;
    });

    window.location.href = "/Produtos/ListarPorBairros?" + param;

}