using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Consultar_Estoque
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }

        public string unidademed_prod { get; set; }
        public string datavalidade_prod { get; set; }
        public string tipo_prod { get; set; }
        public string estoque_prod { get; set; }
        public string fabricante_prod { get; set; }
        public string marca_prod { get; set; }
        public string codbarras_prod { get; set; }
        public string comissao_prod { get; set; }
        public string preco_prod { get; set; }
        public string custo_prod { get; set; }
        public string descricao_prod { get; set; }


         
    }
}
