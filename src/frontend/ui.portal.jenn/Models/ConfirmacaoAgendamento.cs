using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ConfirmacaoAgendamento
{
    public string carteirinhaConvenio { get; set; }
    public bool contraste { get; set; }
    public bool pacienteTitular { get; set; }
    public int peso { get; set; }
    public int altura { get; set; }
    public string alergiaReacoes { get; set; }
    public int planoID { get; set; }
    public int agendaID { get; set; }
    public int procedimentoEmpresaID { get; set; }
    public Cliente cliente { get; set; }
    public Paciente paciente { get; set; }
}

public class Cliente
{
    public int clienteID { get; set; }
    public string nome { get; set; }
    public string sobrenome { get; set; }
    public DateTime dtaNascimento { get; set; }
    public string cpf_cliente { get; set; }
    public string sexo { get; set; }
    public string telefone { get; set; }
    public string celular { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string bairro { get; set; }
    public string cep { get; set; }
    public string referencia { get; set; }
}

public class Paciente
{
    public int pacienteID { get; set; }
    public string nome { get; set; }
    public string sobrenome { get; set; }
    public DateTime dtaNascimento { get; set; }
    public string cpf_paciente { get; set; }
    public string sexo { get; set; }
    public string telefone { get; set; }
    public string celular { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string bairro { get; set; }
    public string cep { get; set; }
    public string referencia { get; set; }
}
