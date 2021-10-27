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
    /// Lógica interna para Tela_Pagamento.xaml
    /// </summary>
    public partial class Tela_Pagamento : Window
    {
        double preco;
        string pagamento;
        public Tela_Pagamento(double valor)
        {
            preco = valor;
            InitializeComponent();
            Loaded += Tela_Pagamento_Loaded;
        }

        public Tela_Pagamento()
        {
            InitializeComponent();
            Loaded += Tela_Pagamento_Loaded;
        }

        private void Tela_Pagamento_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_valor.Text = Convert.ToString(preco);
            lbl_preco_fim.Text = Convert.ToString(preco);
            

        }

        private void lbl_pagamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            pagamento = lbl_pagamento.Text;

            forma_de_pagamento.Text = pagamento;

        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
        }

        private void btn_cadastros_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Cadastros submenu_cadastrar = new SubMenu_Cadastros();
            submenu_cadastrar.ShowDialog();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup_Venda_Realizada popup = new Popup_Venda_Realizada();
            popup.ShowDialog();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void loadPagameto()
        {
            
        }
    }
}
