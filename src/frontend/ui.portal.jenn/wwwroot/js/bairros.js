function buscarBairros() {
    var count = $("[id*='checkbairro_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    $("[id*='checkbairro_']:checked").each(function () {
        model.push($(this).attr("data-bairro"));

        if (i > 0)
            param += "&";

        param += "model[" + i + "]=" + $(this).attr("data-bairro");
        i++;
    });

    window.location.href = "https://" + window.location.host + "/Produtos/ListarPorBairros?" + param;

}