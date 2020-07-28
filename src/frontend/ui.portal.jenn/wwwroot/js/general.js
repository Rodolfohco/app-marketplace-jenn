
function apliqueCount(id, idaplique) {
    var count = $("[id*='" + id + "']:checked").length;
    $("#" + idaplique).html("Aplique(" + count + ")");

    if (count == 0)
        $("#" + idaplique).css("background", "#eaae7d");
    else
        $("#" + idaplique).css("background", "#f36d00");
}

function pesquisar(id, idcheck, dataid) {
    var valor = $("#" + id).val();
    valor = valor.toLowerCase();
    if (valor) {
        $("[id*='" + idcheck + "']").parents(".content-list").hide();
        $("[" + dataid + "*='" + valor + "']").parents(".content-list").show();
    } else {
        $("[id*='" + idcheck + "']").parents(".content-list").show();
    }
}