function buscarporpagamentos() {
    var count = $("[class*='checkpagamento_']:checked").length;

    if (count == 0)
        return;

    var param = "";
    var model = [];
    var i = 0;
    var contador = $("[class*='checkpagamento_']:checked").length;

    if (contador > 0)
        contador = (contador / 2) - 1;

    $("[class*='checkpagamento_']:checked").each(function () {
        if (i <= contador) {
            model.push($(this).attr("data-pagamento"));

            if (i > 0)
                param += "&";

            
            param += "pagamento[" + i + "]=" + $(this).attr("data-pagamento");

        }
           
        
        i++;
    });
     
    var id = $("#idProcedimento").val();
    window.location.href = "/Produtos/ListarPorPagamentos?idProcedimento=" + id + "&" + param;

}