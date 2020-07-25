using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class EmpresaViewModel
    {
        public int EmpresaID { get; set; }
        public string cnpj { get; set; }
        public string Nome { get; set; }
        public int? MatrizID { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string ImgemFrontEmpresa { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string maps { get; set; }
        public string Responsavel { get; set; }
        public string Id_classe { get; set; }
        public string Cert_Empresa { get; set; }
        public int Ativo { get; set; }

        public EmpresaViewModel Matriz { get; set; }
        public ICollection<CidadeViewModel> Cidades { get; set; }
    }  
}