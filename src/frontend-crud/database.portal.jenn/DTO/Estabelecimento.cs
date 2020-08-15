using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.portal.jenn.DTO
{
    public class Estabelicimento
    {

        [Key]       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstabelicimentoID { get; set; }
        public string CO_CNES { get; set; }
        public string NU_CNPJ_MANTENEDORA { get; set; }
        public string TP_PFPJ { get; set; }
        public string NIVEL_DEP { get; set; }
        public string NO_RAZAO_SOCIAL { get; set; }
        public string NO_FANTASIA { get; set; }
        public string NO_LOGRADOURO { get; set; }
        public string NU_ENDERECO { get; set; }
        public string NO_COMPLEMENTO { get; set; }
        public string NO_BAIRRO { get; set; }
        public string CO_CEP { get; set; }
        public string CO_REGIAO_SAUDE { get; set; }
        public string CO_MICRO_REGIAO { get; set; }
        public string CO_DISTRITO_SANITARIO { get; set; }
        public string CO_DISTRITO_ADMINISTRATIVO { get; set; }
        public string NU_TELEFONE { get; set; }
        public string NU_FAX { get; set; }
        public string NO_EMAIL { get; set; }
        public string NU_CPF { get; set; }
        public string NU_CNPJ { get; set; }
        public string CO_ATIVIDADE { get; set; }
        public string CO_CLIENTELA { get; set; }
        public string NU_ALVARA { get; set; }
        public string DT_EXPEDICAO { get; set; }
        public string TP_ORGAO_EXPEDIDOR { get; set; }
        public string DT_VAL_LIC_SANI { get; set; }
        public string TP_LIC_SANI { get; set; }
        public string TP_UNIDADE { get; set; }
        public string CO_TURNO_ATENDIMENTO { get; set; }
        public string CO_ESTADO_GESTOR { get; set; }
        public string CO_MUNICIPIO_GESTOR { get; set; }
        public string DT_ATUALIZACAO { get; set; }
        public string CO_USUARIO { get; set; }
        public string CO_CPFDIRETORCLN { get; set; }
        public string REG_DIRETORCLN { get; set; }
        public string ST_ADESAO_FILANTROP { get; set; }
        public string CO_MOTIVO_DESAB { get; set; }
        public string NO_URL { get; set; }
        public string NU_LATITUDE { get; set; }
        public string NU_LONGITUDE { get; set; }
        public string DT_ATU_GEO { get; set; }
        public string NO_USUARIO_GEO { get; set; }
        public string CO_NATUREZA_JUR { get; set; }
        public string TP_ESTAB_SEMPRE_ABERTO { get; set; }
        public string ST_GERACREDITO_GERENTE_SGIF { get; set; }
        public string ST_CONEXAO_INTERNET { get; set; }
        public string CO_TIPO_UNIDADE { get; set; }
        public string NO_FANTASIA_ABREV { get; set; }
        public string TP_GESTAO { get; set; }
        public string DT_ATUALIZACAO_ORIGEM { get; set; }
        public string CO_TIPO_ESTABELECIMENTO { get; set; }
        public string CO_ATIVIDADE_PRINCIPAL { get; set; }
        public string ST_CONTRATO_FORMALIZADO { get; set; }

    }
}
