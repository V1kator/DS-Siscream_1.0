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
    /// Lógica interna para Cadastrar_Funcionario.xaml
    /// </summary>
    public partial class Cadastrar_Funcionario : Window
    {
        public Cadastrar_Funcionario()
        {
            InitializeComponent();
        }

        private void vai_tela_subproduto(object sender, RoutedEventArgs e)
        {
            Sub_menu_produto subproduto = new Sub_menu_produto();
            subproduto.ShowDialog();
        }

        private void botao_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void botao_vendas_Click(object sender, RoutedEventArgs e)
        {
            Sub_Vendas subvendas = new Sub_Vendas();
            subvendas.ShowDialog();
        }

        private void botaos_gastos_Click(object sender, RoutedEventArgs e)
        {
            Sub_gastos subgastos = new Sub_gastos();
            subgastos.ShowDialog();
        }

        private void botao_escravos_Click(object sender, RoutedEventArgs e)
        {
            Sub_menu_cadastrar subcadastrar = new Sub_menu_cadastrar();
            subcadastrar.ShowDialog();
        }

        private void btn_cadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            Popup_Cadastro_Funcionario popupAlerta = new Popup_Cadastro_Funcionario();
            popupAlerta.ShowDialog();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Funcionario popupEditar = new Popup_Editar_Funcionario();
            popupEditar.ShowDialog();
        }

        private void btn_demitir_Click(object sender, RoutedEventArgs e)
        {
            Popup_Demitir_Funcionario popupDemitir = new Popup_Demitir_Funcionario();
            popupDemitir.ShowDialog();
        }
    }
}

