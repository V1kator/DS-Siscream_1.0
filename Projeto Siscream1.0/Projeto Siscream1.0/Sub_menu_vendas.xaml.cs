﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projeto_Siscream1._0
{
    /// <summary>
    /// Lógica interna para Sub_Vendas.xaml
    /// </summary>
    public partial class Sub_Vendas : Window
    {
        public Sub_Vendas()
        {
            InitializeComponent();
        }

        private void vai_sair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}