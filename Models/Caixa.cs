using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Caixa
    {
        public string nome_func { get; set; }
        public double saldo { get; set; }
        public int senha { get; set; }
        public DateTime aberto { get; set; }
        public DateTime fechado { get; set; }
        public double valorAbertura { get; set; }
        public double suprimento { get; set; }
        public double dinheiroCX { get; set; }
        public double creditoCX { get; set; }
        public double debitoCX { get; set; }
        public double totalCX { get; set; }
        public double valorRetirado { get; set; }
        public string especif { get; set; }
        public double saldoFinal { get; set; }

    }
}
