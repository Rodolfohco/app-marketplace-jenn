using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

public class DTOEmpresa
{
    public bool success { get; set; }
    public string message { get; set; }
    public ProcedimentoEmpresa[] data { get; set; }
    public int status { get; set; }
}

public class ProcedimentoEmpresa
{
    public int procedimentoEmpresaID { get; set; }
    public DateTime dataInclusao { get; set; }
    public string nome_pers { get; set; }
    public int precoProduto { get; set; }
    public int preco_contra { get; set; }
    public string taxaParcelamento { get; set; }
    public string taxaResultado { get; set; }
    public string imagemThumb { get; set; }
    public string imagemHome { get; set; }
    public string imagemMain { get; set; }
    public string video { get; set; }
    public int ativo { get; set; }
    public Empresa empresa { get; set; }
    public Procedimento procedimento { get; set; }
    public object[] procedimentoPerguntas { get; set; }
}

public class Empresa
{
    public int empresaID { get; set; }
    public string cnpj { get; set; }
    public string nome { get; set; }
    public object matrizID { get; set; }
    public string telefone1 { get; set; }
    public string telefone2 { get; set; }
    public string imgemFrontEmpresa { get; set; }
    public string email { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string bairro { get; set; }
    public string cep { get; set; }
    public string maps { get; set; }
    public string responsavel { get; set; }
    public string id_classe { get; set; }
    public string cert_Empresa { get; set; }
    public int ativo { get; set; }
    public object[] matrizes { get; set; }
    public Cidade[] cidades { get; set; }
}

public class Cidade
{
    public int cidadeID { get; set; }
    public string nome { get; set; }
    public string uf { get; set; }
    public object[] regiao { get; set; }
    public object[] ufs { get; set; }
}

public class Procedimento
{
    public int procedimentiID { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public string imgProduto_Proc { get; set; }
    public int ativo { get; set; }
    public Tipoprocedimento tipoProcedimento { get; set; }
}

public class Tipoprocedimento
{
    public int tipoProcedimentoID { get; set; }
    public string nome { get; set; }
    public object categoria { get; set; }
}
