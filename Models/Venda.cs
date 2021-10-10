using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Venda
    {

        /*cod_venda -- codigo
        valor_venda -- valor 
        formaPagamento_venda -- pagamento
        data_venda -- data
        cod_caixa_fk -- caixa*/

        public int Codigo { get; set; }
        public float Valor { get; set; }
        public string Pagamento { get; set; }
        public DateTime Data { get; set; }
        public int Caixa { get; set; }
    }
}
