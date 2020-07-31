function buscarprocedimentos() {
    var count = $("[class*='checkprocedimento_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;

    var contador = $("[class*='checkprocedimento_']:checked").length;

    if (contador > 0)
        contador = (contador / 2) - 1;

    $("[class*='checkprocedimento_']:checked").each(function () {

        if (i <= contador) {
            model.push($(this).attr("data-procedimento"));

            if (i > 0)
                param += "&";

            param += "procedimento[" + i + "]=" + $(this).attr("data-procedimento");
        }

        i++;
    });

    window.location.href = "/Produtos/ListarPorServicos?" + param;

}