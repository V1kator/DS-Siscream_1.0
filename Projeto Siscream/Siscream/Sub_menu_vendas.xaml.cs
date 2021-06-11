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

namespace Siscream
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

        private void vai_tela_subproduto(object sender, RoutedEventArgs e)
        {
            Sub_menu_produto subproduto = new Sub_menu_produto();
            subproduto.ShowDialog();
        }

        private void vai_tela_subvendas(object sender, RoutedEventArgs e)
        {
            Sub_Vendas subvendas = new Sub_Vendas();
            subvendas.ShowDialog();
        }

        private void vai_tela_subgastos(object sender, RoutedEventArgs e)
        {
            Sub_gastos subgastos = new Sub_gastos();
            subgastos.ShowDialog();
        }

        private void vai_tela_subcadastrar(object sender, RoutedEventArgs e)
        {
            Sub_menu_cadastrar subcadastrar = new Sub_menu_cadastrar();
            subcadastrar.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaixaAberto vender = new CaixaAberto();
            vender.ShowDialog();
        }
    }
}
