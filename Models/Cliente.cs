using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Cliente 
    { 
    
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Inscricao { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public Endereco End { get; set; } = new Endereco();

    }

}
