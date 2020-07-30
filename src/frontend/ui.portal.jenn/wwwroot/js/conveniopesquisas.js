function buscarporconveniopesquisas() {
    var count = $("[class*='checkconveniopesquisas_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    var contador = $("[class*='checkconveniopesquisas_']:checked").length;

    if (contador > 0)
        contador = (contador / 2) - 1;

    $("[class*='checkconveniopesquisas_']:checked").each(function () {

        if (i <= contador) {

            model.push($(this).attr("data-bairro"));

            if (i > 0)
                param += "&";
             
            param += "conveniopesquisas[" + i + "]=" + $(this).attr("data-conveniopesquisas");
        }
        i++;
    });

    window.location.href = "https://" + window.location.host + "/Produtos/ListarPorConvenio?" + param;
}
