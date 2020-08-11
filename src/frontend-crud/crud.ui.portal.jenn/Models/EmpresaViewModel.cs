
using crud.ui.portal.jenn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{

    public class NovaEmpresaViewModel
    {

        [Required(ErrorMessage = "Informe o CNEs da EmpresaJ")]
        [Display(Name = "Código CNEs da Empresa :")]
        public string codCnes { get; set; }



        [Required(ErrorMessage = "Informe o Numero do CNPJ")]
        [Display(Name = "CNPJ Da Empresa :")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Empresa")]
        [Display(Name = "Nome Empresa :")]
        public string Nome { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Informe o Telefone")]
        [Display(Name = "Telefone :")]
        public string Telefone1 { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone :")]
        public string Telefone2 { get; set; }


        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Informe a Logomarca da Empresa")]
        [Display(Name = "Logomarca da Empresa :")]
        public string ImgemFrontEmpresa { get; set; }



        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o E-mail da Empresa")]
        [Display(Name = "E-Mail :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Endereço da Empresa")]
        [Display(Name = "Endereço :")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Numero da Empresa")]
        [Display(Name = "Numero :")]
        public string numero { get; set; }

        [Required(ErrorMessage = "Informe o bairro da Empresa")]
        [Display(Name = "Bairro :")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "Informe o CEP da Empresa")]
        [Display(Name = "Cep :")]
        public string cep { get; set; }


        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Informe o Link Google Maps da Empresa")]
        [Display(Name = "Link Google Maps :")]
        public string maps { get; set; }

        [Required(ErrorMessage = "Informe o Responsavel da Empresa")]
        [Display(Name = "Responsavel :")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "Informe a Classificação da Empresa")]
        [Display(Name = "Classificação :")]
        public string Id_classe { get; set; }

        [Required(ErrorMessage = "Informe a Cert-Empresa da Empresa")]
        [Display(Name = "Cert-Empresa :")]
        public string Cert_Empresa { get; set; }

        [Required(ErrorMessage = "Informe o Tipo de Cliente da Empresa")]
        [Display(Name = "Tipo Cliente :")]
        public int TipoCliente { get; set; }

        [Required]
        public int Ativo { get; set; }



        [Display(Name = "Selecione a Empresa Matriz :")]
        [Required(ErrorMessage = "Selecione a ")]
        public int MatrizID { get; set; }

        public CidadeViewModel Cidade { get; set; }
    }

    


        public class ConsultaEmpresaViewModel
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


        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
        public EmpresaViewModel Matriz { get; set; }
        public ICollection<ConsultaProcedimentoEmpresaViewModel> ProcedimentoEmpresas { get; set; }
    }



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


        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
        public EmpresaViewModel Matriz { get; set; }
        public ICollection<ProcedimentoEmpresaViewModel> ProcedimentoEmpresas { get; set; }
    }



    public class NovaFilialViewModel
    {
        public int? MatrizID { get; set; }
        public string cnpj { get; set; }
        public string Nome { get; set; }
      
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

 
    }

    public class FilialViewModel
    {
        public int? MatrizID { get; set; }

        public int EmpresaID { get; set; }

        public string cnpj { get; set; }
        public string Nome { get; set; }

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


        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
        public EmpresaViewModel Matriz { get; set; }
        public ICollection<ProcedimentoEmpresaViewModel> ProcedimentoEmpresas { get; set; }
    }


    public class ConsultaFilialViewModel
    {
        public int? MatrizID { get; set; }
        public int EmpresaID { get; set; }

        public string cnpj { get; set; }
        public string Nome { get; set; }

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
        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
        public ConsultaEmpresaViewModel Matriz { get; set; }
        public ICollection<ConsultaProcedimentoEmpresaViewModel> ProcedimentoEmpresas { get; set; }
    }

}