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
    /// Lógica interna para Cadastrar_cliente.xaml
    /// </summary>
    public partial class Cadastrar_cliente : Window
    {
        public Cadastrar_cliente()
        {
            InitializeComponent();
        }

        private void vai_tela_subproduto(object sender, RoutedEventArgs e)
        {
            Sub_menu_produto subproduto = new Sub_menu_produto();
            subproduto.ShowDialog();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar_produto produto = new Cadastrar_produto();
            produto.ShowDialog();
        }

        private void botaos_gastos_Click(object sender, RoutedEventArgs e)
        {
            Sub_gastos subgastos = new Sub_gastos();
            subgastos.ShowDialog();
        }

        private void botao_vendas_Click(object sender, RoutedEventArgs e)
        {
            Sub_Vendas subvendas = new Sub_Vendas();
            subvendas.ShowDialog();
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

        private void btn_cadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            Popup_Cadastrar_cliente cadastrarcliente = new Popup_Cadastrar_cliente();
            cadastrarcliente.ShowDialog();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Cliente popupEditar = new Popup_Editar_Cliente();
            popupEditar.ShowDialog();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Cancelar_Cliente popup_Cancelar = new Popup_Cancelar_Cliente();
            popup_Cancelar.ShowDialog();
        }
    }
}
