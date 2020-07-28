
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

function autocompleteConvenio(element) {
    var valor = $(element).val();
    valor = valor.toLowerCase();
    var divconvenio = $(element).parent(".divconvenio")
    
    if (valor) {
        $(divconvenio).find(".convenio").hide();
        $(divconvenio).find(".convenio[data-convenio*='" + valor + "']").show();
    } else {
        $(divconvenio).find(".convenio").hide();
    }
}


function selecionarConvenio(valor, elementos) {

    var divconvenio = $(elementos).parents(".divconvenio");
    var input = $(divconvenio).find("input");
    $(input).val(valor);
}