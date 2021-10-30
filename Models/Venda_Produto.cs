using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.Models;
using Siscream.DataBase;
using MySql.Data.MySqlClient;

namespace Siscream.Models
{
   public class Venda_Produto 
    {
        public int Codigo { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double ValorTotal { get; set; }
        public Produto Produto { get; set; } = new Produto();
    }
}
