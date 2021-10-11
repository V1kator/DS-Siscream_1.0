using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{

    class Fechar_Caixa
    {

        public string nome_func {get; set;}
        public DateTime caixa_aberto { get; set; }
        public DateTime caixa_fechado { get; set; }
        public double saldo_inicial { get; set; }
        public double suprimento { get; set; }
        public double dinheiro { get; set; }
        public double cartao_cred { get; set; }
        public double cartao_deb { get; set; }
        public double total_entrada { get; set; }
        public double valor_retirada { get; set; }
        public string especificacoes { get; set; }
        public double saldo_final { get; set; }
    }
}
