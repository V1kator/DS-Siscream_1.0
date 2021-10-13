using System;
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
using Siscream.Models;

namespace Siscream.Views
{
    /// <summary>
    /// Lógica interna para AdicionarGastos.xaml
    /// </summary>
    public partial class AdicionarGastos : Window
    {
        public AdicionarGastos()
        {
            InitializeComponent();
        }
        private void vai_tela_subproduto(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos subproduto = new SubMenu_Produtos();
            subproduto.ShowDialog();
        }

        private void botao_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void botao_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas subvendas = new SubMenu_Vendas();
            subvendas.ShowDialog();
        }

        private void botaos_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos subgastos = new SubMenu_Gastos();
            subgastos.ShowDialog();
        }

        private void botao_escravos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Cadastros subcdastro = new SubMenu_Cadastros();
            subcdastro.ShowDialog();
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void excluir(object sender, RoutedEventArgs e)
        {

        }

        private void botao_adg_Click(object sender, RoutedEventArgs e)
        {
            LancarGastprod ldp = new LancarGastprod();
            ldp.ShowDialog();
            this.Close();
        }

    }
}
