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
    /// Lógica interna para Fechar_Caixa.xaml
    /// </summary>
    public partial class Fechar_Caixa : Window
    {
        public Fechar_Caixa()
        {
            InitializeComponent();
            Loaded += Fechar_Caixa_Loaded;

        }

        private void Fechar_Caixa_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxs();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {         
                Caixa cx = new Caixa();
                Funcionario funcionario = new Funcionario();
                cx.id = Convert.ToInt32(ID.Text); 

                funcionario.Nome = func_nome.Text;

                cx.saldoInicial = Convert.ToDouble(saldoIn.Text);
                cx.dinheiroCX = Convert.ToDouble(dinheiro.Text);
                cx.creditoCX = Convert.ToDouble(credito.Text);
                cx.debitoCX = Convert.ToDouble(debito.Text);
                cx.totalCX = Convert.ToDouble(total.Text);
                cx.valorRetirado = Convert.ToDouble(Vretirado.Text);
                cx.especif = especif.Text;
                cx.saldoFinal = Convert.ToDouble(Sfinal.Text);

                CaixaDAO cxDAO = new CaixaDAO(); 
                cxDAO.FecharCaixa(cx);
                Funcionario_DAO funcionarioDAO = new Funcionario_DAO();
                funcionarioDAO.Insert(funcionario);

                PopUp_Salvar_FecharCaixa caixa = new PopUp_Salvar_FecharCaixa();
                caixa.ShowDialog();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

             
          
        }


        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Cancelar_FecharCaixa caixa = new PopUp_Cancelar_FecharCaixa();
            caixa.ShowDialog();
            this.Close();
        }
        
           
        private void ClearInputs()
        {
            func_nome.Text = "";
            saldoIn.Text = "";
            dinheiro.Text = "";
            credito.Text = "";
            debito.Text = "";
            total.Text = "";
            Vretirado.Text= "";
            especif.Text = "";
            Sfinal.Text = "";
        }
                
        private void LoadComboBoxs()
        {
            try
            {
                func_nome.ItemsSource = new Funcionario_DAO().List();
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
