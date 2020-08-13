﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class AgendamentoViewModel
    { 
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string CelularPaciente { get; set; }
        public string EmailPaciente { get; set; }
        public string AlgumaAlergia { get; set; }

        public string Carteirinha { get; set; }
        public string CPFSolicitante { get; set; }


        public string NomePaciente { get; set; }
        public string SobrenomePaciente { get; set; }

        public PesquisaViewModel PesquisaViewModel { get; set; }


        public List<string> Convenios { get; set; }
    }
}
