function buscarCidades() {
    var count = $("[class*='checkcidade_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;

    var contador = $("[class*='checkcidade_']:checked").length;

    if (contador > 0)
        contador = (contador / 2) - 1;

    $("[class*='checkcidade_']:checked").each(function () {

        if (i <= contador) {
            model.push($(this).attr("data-cidade"));

            if (i > 0)
                param += "&";

            param += "cidade[" + i + "]=" + $(this).attr("data-cidade");
        }
        i++;
    });


    var id = $("#idProcedimento").val();
    window.location.href = "/Produtos/ListarPorCidades?idProcedimento=" + id + "&" + param;

}