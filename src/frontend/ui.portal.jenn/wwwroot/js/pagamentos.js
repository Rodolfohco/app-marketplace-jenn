function buscarporpagamentos() {
    var count = $("[id*='checkpagamento_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    $("[id*='checkpagamento_']:checked").each(function () {
        model.push($(this).attr("data-pagamento"));

        if (i > 0)
            param += "&";

        param += "model[" + i + "]=" + $(this).attr("data-pagamento");
        i++;
    });

    window.location.href = "https://" + window.location.host + "/Produtos/ListarPorPagamentos?" + param;


}