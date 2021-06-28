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
    /// Lógica interna para SubMenu_Vendas.xaml
    /// </summary>
    public partial class SubMenu_Vendas : Window
    {
        public SubMenu_Vendas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos submenu_produtos = new SubMenu_Produtos();
            submenu_produtos.ShowDialog();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
            this.Close();
        }

        private void btn_cadastros_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Cadastros submenu_cadastrar = new SubMenu_Cadastros();
            submenu_cadastrar.ShowDialog();
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Selecionar_Vendedor selecione = new Selecionar_Vendedor();
            selecione.ShowDialog();
            this.Close();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas venda = new SubMenu_Vendas();
            venda.ShowDialog();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
=======
            Abrir_Caixa A_Caixa = new Abrir_Caixa();
            A_Caixa.ShowDialog();
>>>>>>> main
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            this.Close();
=======
            Fechar_Caixa F_caixa = new Fechar_Caixa();
            F_caixa.ShowDialog();
            this.Close();
           
>>>>>>> main
        }
    }
}
