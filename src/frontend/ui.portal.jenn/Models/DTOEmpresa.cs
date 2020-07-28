using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class DTOEmpresa
{
    public object token { get; set; }
    public bool success { get; set; }
    public string message { get; set; }
    public Empresa[] data { get; set; }
    public int status { get; set; }
}

public class Empresa
{
    public int empresaID { get; set; }
    public string cnpj { get; set; }
    public string nome { get; set; }
    public int? matrizID { get; set; }
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
    public object grupo { get; set; }
    public Cidade cidade { get; set; }
    public object[] fotos { get; set; }
    public object[] avaliacoes { get; set; }
    public Matriz matriz { get; set; }
    public ProcedimentoEmpresa[] procedimentoEmpresas { get; set; }
}

public class Cidade
{
    public int cidadeID { get; set; }
    public string nome { get; set; }
    public Regiao[] regiao { get; set; }
    public Uf[] ufs { get; set; }
}

public class Regiao
{
    public int regiaoID { get; set; }
    public string nome { get; set; }
}

public class Uf
{
    public int ufID { get; set; }
    public string nome { get; set; }
}

public class Matriz
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
    public object grupo { get; set; }
    public Cidade cidade { get; set; }
    public object[] fotos { get; set; }
    public object[] avaliacoes { get; set; }
    public object matriz { get; set; }
    public ProcedimentoEmpresa[] procedimentoEmpresas { get; set; }
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
    public Procedimento procedimento { get; set; }
    public object[] planoProcedimentoEmpresas { get; set; }
    public object[] procedimentoPerguntas { get; set; }
    public PagamentoProcedimentoEmpresa[] pagamentoProcedimentoEmpresas { get; set; }
}

public class Procedimento
{
    public int procedimentoID { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public string imgProduto_Proc { get; set; }
    public int ativo { get; set; }
    public TipoProcedimento tipoProcedimento { get; set; }
}

public class TipoProcedimento
{
    public int tipoProcedimentoID { get; set; }
    public string nome { get; set; }
    public Categoria categoria { get; set; }
}

public class Categoria
{
    public int categoriaID { get; set; }
    public string nome { get; set; }
}

public class PagamentoProcedimentoEmpresa
{
    public int pagamentoProcedimentoEmpresaID { get; set; }
    public Pagamento pagamento { get; set; }
}

public class Pagamento
{
    public int pagamentoID { get; set; }
    public string nome { get; set; }
}
