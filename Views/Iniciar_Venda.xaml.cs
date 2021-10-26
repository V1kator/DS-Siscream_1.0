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
    /// Lógica interna para Iniciar_Venda.xaml
    /// </summary>
    public partial class Iniciar_Venda : Window
    {
        private List<Produto> prodList = new List<Produto>();
        public Iniciar_Venda()
        {
            InitializeComponent();
            Loaded += Iniciar_Venda_Loaded;
        }

        private void Iniciar_Venda_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tela_Pagamento horadepagar = new Tela_Pagamento();
            horadepagar.ShowDialog();
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cadastrar_Produto cadastrar = new Cadastrar_Produto();
            cadastrar.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var text = txtFilter.Text;
            var filterlist = prodList.Where(i => i.Nome.ToLower().Contains(text));
            filterprodutos.ItemsSource = filterlist;

        }

        private void btn_cadastrarnovo_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar_Produto cadastrar = new Cadastrar_Produto();
            cadastrar.ShowDialog();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Data_venda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void filterprodutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterprodutos.ItemsSource = new Produto_DAO().ListVenda();
        }

        private void filterprodutos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LoadDataGrid()
        {
            try
            {
                prodList = new Produto_DAO().List();
                filterprodutos.ItemsSource = prodList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
}
