using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ClienteViewModel
    {

            public Guid ClienteID { get; set; }
            public string Nome { get; set; }

            public string sobrenome { get; set; }

            public DateTime DtaNascimento { get; set; }
            public string cpf_cliente { get; set; }

            public string Sexo { get; set; }

            public string Telefone { get; set; }

            public string Celular { get; set; }

            public string Logradouro { get; set; }

            public string numero { get; set; }

            public string bairro { get; set; }


            public string Cep { get; set; }

            public string Referencia { get; set; }

        }
    }
