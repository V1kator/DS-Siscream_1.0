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
            try
            {
                Caixa cx = new Caixa();
                cx.aberto = abertoCx.Text;
                cx.fechado = fechadoCx.Text;
                cx.saldoInicial = saldoIn.Text;
                cx.suprimento = suprim.Text;
                cx.dinheiroCX = dinheiro.Text;
                cx.creditoCX = credito.Text;
                cx.debitoCX = debito.Text;
                cx.totalCX = total.Text;
                cx.valorRetirado = Vretirado.Text;
                cx.especif = especif.Text;
                cx.saldoFinal = Sfinal.Text;

                CaixaDAO cxDAO = new CaixaDAO();
                cxDAO.FecharCaixa(cx);

                PopUp_Salvar_FecharCaixa caixa = new PopUp_Salvar_FecharCaixa();
                caixa.ShowDialog();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

             
          
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
        /*##########################################    TESTE ##############################################
        private void FecharCaixa_teste()
        {
            Caixa cx = new Caixa();
            cx.aberto = "11:00";
            cx.fechado = "23:00";
            cx.valorAbertura = 250.00;
            cx.suprimento = 100.00;
            cx.dinheiroCX = 400.00;
            cx.creditoCX = 0;
            cx.debitoCX = 450.00;
            cx.totalCX = 1200.00;
            cx.valorRetirado = 138.00;
            cx.especif = "Pagamento de ingredientes para produção de sorvetes";
            cx.saldoFinal = 1062.00;

            CaixaDAO cxDAO = new CaixaDAO();
            cxDAO.FecharCaixa(cx);
        }*/

        private void ClearInputs()
        {
            
            abertoCx.Text = "";
            fechadoCx.Text = "";
            saldoIn.Text = "";
            suprim.Text = "";
            dinheiro.Text = "";
            credito.Text = "";
            debito.Text = "";
            total.Text = "";
            Vretirado.Text= "";
            especif.Text = "";
            Sfinal.Text = "";
        }

    }

   
}
