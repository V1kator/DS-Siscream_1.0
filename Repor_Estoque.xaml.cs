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
    /// Lógica interna para Repor_Estoque.xaml
    /// </summary>
    public partial class Repor_Estoque : Window
    {
        public Repor_Estoque()
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
                

        private void But_salvar_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Salvar_Reposicao popUp = new PopUp_Salvar_Reposicao();
            popUp.ShowDialog();
            this.Close();
        }

        private void But_cancelar_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Cancelar_Reposicao_Estoque popUp = new PopUp_Cancelar_Reposicao_Estoque();
            popUp.ShowDialog();
           
        }

        private void nome_prod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void preco_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Quant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    
}
