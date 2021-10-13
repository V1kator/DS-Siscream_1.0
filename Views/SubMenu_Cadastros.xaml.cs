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

namespace Siscream.Views
{
    /// <summary>
    /// Lógica interna para SubMenu_Cadastros.xaml
    /// </summary>
    public partial class SubMenu_Cadastros : Window
    {
        public SubMenu_Cadastros()
        {
            InitializeComponent();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
            this.Close();
        }

        private void botao_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos submenu_produtos = new SubMenu_Produtos();
            submenu_produtos.ShowDialog();
        }

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cadastrar_Funcionario cad_funcionario = new Cadastrar_Funcionario();
            cad_funcionario.ShowDialog();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Cadastrar_Cliente cad_Cliente = new Cadastrar_Cliente();
            cad_Cliente.ShowDialog();
            this.Close();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void btn_cadastros_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Cadastros cadastro = new SubMenu_Cadastros();
            cadastro.ShowDialog();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Consultar_Cliente Consul_clien = new Consultar_Cliente();
            Consul_clien.ShowDialog();
            this.Close();
        }
    }
}
