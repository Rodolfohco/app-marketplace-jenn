using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{

    public class NovaEmpresaViewModel
    {
        public string CodigoCnes { get; set; }
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
        public int TipoEmpresa { get; set; }

        public string url_loja { get; set; }

    }





    public class ConsultaEmpresaViewModel
    {
        public string CodigoCnes { get; set; }
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

        public int TipoEmpresa { get; set; }

        public string url_loja { get; set; }


        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
       public EmpresaMatrizViewModel Matriz { get; set; }
        public ICollection<ConsultaProcedimentoEmpresaViewModel> ProcedimentoEmpresas { get; set; }
    }


    public class EmpresaMatrizViewModel
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
        public int TipoEmpresa { get; set; }
        public string CodigoCnes { get; set; }

        public string url_loja { get; set; }

        public GrupoViewModel Grupo { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public ICollection<FotoEmpresaViewModel> Fotos { get; set; }
        public ICollection<AvaliaViewModel> Avaliacoes { get; set; }
        public EmpresaViewModel Matriz { get; set; }
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
        public int TipoEmpresa { get; set; }
        public string CodigoCnes { get; set; }

        public string url_loja { get; set; }

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
        public int TipoEmpresa { get; set; }
        public string CodigoCnes { get; set; }
        public string url_loja { get; set; }
    }

    public class FilialViewModel
    {
        public int TipoEmpresa { get; set; }
        public string CodigoCnes { get; set; }
        public string url_loja { get; set; }

        public int? MatrizID { get; set; }

        [AutoMapper.IgnoreMap]
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
        public int TipoEmpresa { get; set; }
        public string CodigoCnes { get; set; }
        public string url_loja { get; set; }

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