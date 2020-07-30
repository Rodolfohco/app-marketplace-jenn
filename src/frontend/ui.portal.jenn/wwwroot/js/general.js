
function apliqueCount(id, idaplique, elemento) {
    var valor = elemento.checked;
    var classe = $(elemento).attr("class");
    var classelemento = $("." + classe.replace(" ", "."))

    for (var i = 0; i < classelemento.length; i++) {
        $(classelemento)[i].checked = valor;
    }

    var count = $("[class*='" + id + "']:checked").length;


    if (count == 0) {
        $("." + idaplique).css("background", "#eaae7d");
    }
    else {
        $("." + idaplique).css("background", "#f36d00");
        count = count / 2;
    }
       
    $("." + idaplique).html("Aplique(" + count + ")");
    $("." + idaplique).attr("data-count", count);

    $("#todosfiltros .botoesfiltro").remove();
    var contador = 0;

    for (var i = 0; i < $("[data-count]").length; i++) {
        contador += parseInt($($("[data-count]")[i]).attr("data-count"));
    }
    
    if (contador == 0) {
        $("#botaofiltrartodos").css("background", "#eaae7d");
    }
    else {
        $("#botaofiltrartodos").css("background", "#f36d00");
    }

    $("#botaofiltrartodos").html("Aplique(" + contador + ")");
}

function pesquisar(elemento, idcheck, dataid) {
    var valor = $(elemento).val();
    valor = valor.toLowerCase();
    if (valor) {
        $("[class*='" + idcheck + "']").parents(".content-list").hide();
        $("[" + dataid + "*='" + valor + "']").parents(".content-list").show();
    } else {
        $("[class*='" + idcheck + "']").parents(".content-list").show();
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