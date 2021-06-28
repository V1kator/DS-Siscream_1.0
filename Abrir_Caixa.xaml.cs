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
    /// Lógica interna para Abrir_Caixa.xaml
    /// </summary>
    public partial class Abrir_Caixa : Window
    {
        public Abrir_Caixa()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
=======

>>>>>>> main
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

        private void botao_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void botao_abrir_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
           // PopUp_Abrir_Caixa PupUp = new PopUp_Abrir_Caixa();
           // PupUp.ShowDialog();
=======
           PopUp_Abrir_Caixa PupUp = new PopUp_Abrir_Caixa();
           PupUp.ShowDialog();
>>>>>>> main
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
<<<<<<< HEAD
=======

        private void Funcionario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
>>>>>>> main
    }
}

