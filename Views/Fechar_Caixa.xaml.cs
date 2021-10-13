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
            PopUp_Salvar_FecharCaixa caixa = new PopUp_Salvar_FecharCaixa();
            caixa.ShowDialog();
            this.Close();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Fechar_Caixa tela = new Fechar_Caixa();
            tela.ShowDialog();
            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Cancelar_FecharCaixa caixa = new PopUp_Cancelar_FecharCaixa();
            caixa.ShowDialog();
            this.Close();
        }

        private void Insert_Teste()
        {
            try
            {
                Caixa FecharCaixa = new Caixa();
                FecharCaixa.nome_func = "Thallia";
                FecharCaixa.aberto = "11:00 Hrs";
                FecharCaixa.fechado = "22:00 Hrs";
                FecharCaixa.valorAbertura = 150.00;
                FecharCaixa.suprimento = 0;
                FecharCaixa.dinheiroCX = 300.00;
                FecharCaixa.creditoCX = 230.00;
                FecharCaixa.debitoCX = 750.00;
                FecharCaixa.totalCX = 1280.00;
                FecharCaixa.valorRetirado = 125.50;
                FecharCaixa.especif = "Pagamento de 30L de leite";
                FecharCaixa.saldoFinal = 1154.5;

                FecharCaixaDAO FecharCaixaDAO = new FecharCaixaDAO();
                FecharCaixaDAO.Insert(FecharCaixa);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                     
        }
    }
}
