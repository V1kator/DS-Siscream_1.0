using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Consultar_Estoque
    {
        public int cod_prod { get; set; }
        public string nome_prod { get; set; }
        public string unidademed_prod { get; set; }
        public DateTime datavalidade_prod { get; set; }
        public string tipo_prod { get; set; }
        public int estoque_prod { get; set; }
        public string fabricante_prod { get; set; }
        public string marca_prod { get; set; }
        public string codbarras_prod { get; set; }
        public int comissao_prod { get; set; }
        public float preco_prod { get; set; }
        public float custo_prod { get; set; }
        public string descricao_prod { get; set; }


         
    }
}
