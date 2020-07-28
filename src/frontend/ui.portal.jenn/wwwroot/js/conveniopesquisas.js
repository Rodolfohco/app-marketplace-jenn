function buscarporconveniopesquisas() {
    var count = $("[id*='checkconveniopesquisas_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    $("[id*='checkconveniopesquisas_']:checked").each(function () {
        model.push($(this).attr("data-bairro"));

        if (i > 0)
            param += "&";

        param += "model[" + i + "]=" + $(this).attr("data-conveniopesquisas");
        i++;
    });

    window.location.href = "https://" + window.location.host + "/Produtos/ListarPorConvenio?" + param;

}