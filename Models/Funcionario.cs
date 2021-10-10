﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Funcionario
    {

        /*Cod_func -- codigo
        nome_func -- nome 
        cpf_func -- cpf
        cargo_func -- cargo
        tipoContrato_func -- contrato
        senha_func -- senha
        dataAdmissao_func -- admissao
        cod_end_fk -- Codigo_end*/

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }  
        public string Cargo { get; set; }
        public string Contrato { get; set; }
        public string Senha { get; set; }
        public DateTime Admissao { get; set; }
        public int Codigo_end { get; set; }
    }
}

