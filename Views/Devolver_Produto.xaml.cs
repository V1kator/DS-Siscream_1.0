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
    /// Lógica interna para Devolver_Produto.xaml
    /// </summary>
    public partial class Devolver_Produto : Window
    {
        public Devolver_Produto()
        {
            InitializeComponent();
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
            PopUp_Funcao_Disponivel_Futuramente fun_disp_futur = new PopUp_Funcao_Disponivel_Futuramente();
            fun_disp_futur.ShowDialog();
        }

        private void bnt_consultar_estoque_interno_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Funcao_Disponivel_Futuramente fun_disp_futur = new PopUp_Funcao_Disponivel_Futuramente();
            fun_disp_futur.ShowDialog();
        }

        private void bnt_cancelar_devolucao_produto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bnt_ok_devolucao_produto_Click(object sender, RoutedEventArgs e)
        {
            
            string nome_produto_devol;
            string quant_prod_devol, id_prod;
            string preco_prod_devol;
            string data_prod_devol;

            nome_produto_devol = Textbox_nome_produto_devolucao_produto.Text;
            quant_prod_devol = Textbox_quantidade_devolucao_produto.Text;
            id_prod = Textbox_id_devolucao_produto.Text;
            preco_prod_devol = Textbox_preco_devolucao_produto.Text;
            data_prod_devol = Data_devolucao_produto.Text;

            MessageBox.Show("Devolução efetuada com sucesso! O produto "+nome_produto_devol+" foi devolvido com sucesso na data: "+ data_prod_devol+". Total a ser reembolsado pelo cliente: "+preco_prod_devol);

        }
    }
}
