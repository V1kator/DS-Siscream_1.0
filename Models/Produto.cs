﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    public class Produto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public DateTime Validade { get; set; }
        public string Tipo { get; set; }
        public int Estoque { get; set; }
        public string Fabricante { get; set; }
        public string Marca { get; set; }
        public string Barras { get; set; }
        public int Comissao { get; set; }
        public double Preco { get; set; }
        public double Custo { get; set; }
        public string Descricao { get; set; }
       

        private bool selected = false;

        public bool IsSelected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        public int Quantidade { get; set; }
    }
}
