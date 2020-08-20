$(document).ready(function () {
    $("#grid").DataTable({
        "pageLength": 50
    });
    


 
    $("#pesquisa").bind("click", function () {

        var valor = $("#cep").val();
        cep = valor.replace(/\D/g, '');

        if (cep !== "") {
            var validacep = /^[0-9]{8}$/;
 
           if (validacep.test(cep)) {

            $.getJSON("https://viacep.com.br/ws/"+ cep +"/json/?callback=?", function(dados) {
                            console.log(dados);
                            if (!("erro" in dados)) {
                                $("#rua").val(dados.logradouro);
                                $("#bairro").val(dados.bairro);
                                $("#sel_cidade").val(dados.ibge.substring(0,6));
                            } 
                            else {
                                alert("CEP não encontrado.");
                             }
            });
           }
        else
            alert("CEP não encontrado.");
        }
        else
            alert("CEP não encontrado.");
    });



});


function somenteNumeros(e) {
        var charCode = e.charCode ? e.charCode : e.keyCode;
        // charCode 8 = backspace   
        // charCode 9 = tab
        if (charCode != 8 && charCode != 9) {
            // charCode 48 equivale a 0   
            // charCode 57 equivale a 9
            if (charCode < 48 || charCode > 57) {
                return false;
            }
        }
    }
 



 
     function formatar(mascara, documento) {
         var i = documento.value.length;
         var saida = mascara.substring(0, 1);
         var texto = mascara.substring(i);

         if (texto.substring(0, 1) != saida) {
             documento.value += texto.substring(0, 1);
         }

     }



     function exibe(i) {
         document.getElementById(i).readOnly = true;
     }

     function desabilita(i) {

         document.getElementById(i).disabled = true;
     }
     function habilita(i) {
         document.getElementById(i).disabled = false;
     }



