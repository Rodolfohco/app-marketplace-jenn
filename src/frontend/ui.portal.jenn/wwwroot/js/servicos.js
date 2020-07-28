function buscarprocedimentos() {
    var count = $("[id*='checkprocedimento_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    $("[id*='checkprocedimento_']:checked").each(function () {
        model.push($(this).attr("data-procedimento"));

        if (i > 0)
            param += "&";

        param += "model[" + i + "]=" + $(this).attr("data-procedimento");
        i++;
    });

    window.location.href = "https://" + window.location.host + "/Produtos/ListarPorServicos?" + param;

}