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
    /// Lógica interna para Cadastrar_Cliente.xaml
    /// </summary>
    public partial class Cadastrar_Cliente : Window
    {
        public Cadastrar_Cliente()
        {
            InitializeComponent();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos submenu_produtos = new SubMenu_Produtos();
            submenu_produtos.ShowDialog();
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

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
            this.Close();
        }

        private void btn_cadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            Popup_Cadastrar_Cliente popup = new Popup_Cadastrar_Cliente();
            popup.ShowDialog();
            this.Close();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Cancelar_Cliente popup = new Popup_Cancelar_Cliente();
            popup.ShowDialog();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Cliente popup = new Popup_Editar_Cliente();
            popup.ShowDialog();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }
<<<<<<< HEAD
=======

        private void lbl_codigo_user_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
>>>>>>> main
    }
}
