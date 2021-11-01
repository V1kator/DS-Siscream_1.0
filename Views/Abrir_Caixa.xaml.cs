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
    /// Lógica interna para Abrir_Caixa.xaml
    /// </summary>
    public partial class Abrir_Caixa : Window
    {
        public Abrir_Caixa()
        {
            InitializeComponent();
            Loaded += Abrir_Caixa_Loaded;
        }

        private void Abrir_Caixa_Loaded(object sender, RoutedEventArgs e)
        {
            
            LoadComboBox();
        }


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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void botao_abrir_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Caixa cx = new Caixa();
                Funcionario funcionario = new Funcionario();


                funcionario.Nome = func_nome.Text;

                cx.data = (DateTime)abertura.SelectedDate;
                cx.saldoInicial = Convert.ToDouble(valorcaixa.Text);


                CaixaDAO cxDAO = new CaixaDAO();
                cxDAO.AbrirCaixa(cx);
                Funcionario_DAO funcionarioDAO = new Funcionario_DAO();
                funcionarioDAO.Insert(funcionario);

                PopUp_Abrir_Caixa caixaA = new PopUp_Abrir_Caixa();
                caixaA.ShowDialog();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

            PopUp_Abrir_Caixa PupUp = new PopUp_Abrir_Caixa();
           PupUp.ShowDialog();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Funcionario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void LoadComboBox()
        {
            try
            {

                var func_select = new Funcionario_DAO().List();

                func_nome.ItemsSource = func_select;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
        private void func_nome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

