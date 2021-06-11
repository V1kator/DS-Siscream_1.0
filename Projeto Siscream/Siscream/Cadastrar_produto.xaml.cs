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
    /// Lógica interna para Cadastrar_produto.xaml
    /// </summary>
    public partial class Cadastrar_produto : Window
    {
        public Cadastrar_produto()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Cadastrar_Produto cadastrar_Produto = new Popup_Cadastrar_Produto();
            cadastrar_Produto.ShowDialog();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Produto popup_Editar_ = new Popup_Editar_Produto();
            popup_Editar_.ShowDialog();
        }

       

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            Popup_Excluir_Cadastro popup_Excluir = new Popup_Excluir_Cadastro();
            popup_Excluir.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sub_menu_produto sub_Menu_Produto = new Sub_menu_produto();
            sub_Menu_Produto.ShowDialog();
        }

        private void botao_vendas_Click(object sender, RoutedEventArgs e)
        {
            Sub_Vendas vender = new Sub_Vendas();
            vender.ShowDialog();
        }

        private void botaos_gastos_Click(object sender, RoutedEventArgs e)
        {
            Sub_gastos gastos= new Sub_gastos();
            gastos.ShowDialog();
        }

        private void botao_escravos_Click(object sender, RoutedEventArgs e)
        {
            Sub_menu_cadastrar cadastrar = new Sub_menu_cadastrar();
            cadastrar.ShowDialog();
        }

        private void botao_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //private void botao_vendas_Click(object sender, RoutedEventArgs e)
        //{
        //    Sub_menu_vendas sub_Menu_Vendas = new Sub_menu_vendas();
        //    sub_Menu_Vendas.ShowDialog();
        //}
    }
}
