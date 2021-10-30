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

        public List<Produto> prodselecionado = new List<Produto>();

        private List<Venda_Produto> _compraItensList = new List<Venda_Produto>();

        private Funcionario _funcionario = new Funcionario();

        double valor = 0;
        public Iniciar_Venda()
        {
            InitializeComponent();
            Loaded += Iniciar_Venda_Loaded;
        }

        public Iniciar_Venda(Funcionario func)
        {
            _funcionario = func;
            InitializeComponent();
            Loaded += Iniciar_Venda_Loaded;
        }

        private void Iniciar_Venda_Loaded(object sender, RoutedEventArgs e)
        {
            Data_venda.SelectedDate = DateTime.Now;
            txtnomefunc.Text = _funcionario.Nome;
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


            var window = new Tela_Pagamento(valor);
            window.ShowDialog();
            this.Close();
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _compraItensList.ForEach(item => valor += item.ValorTotal);

            lbl_preco.Text = valor.ToString("C");

            return valor;
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
        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {

            foreach (Produto produto in prodselecionado)
            {

                if (!_compraItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _compraItensList.Add(new Venda_Produto()
                    {
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.Preco,
                        ValorTotal = produto.Preco
                    }) ;

                }
            }

            LoadDataGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var itens = filterprodutos.Items;

            prodselecionado.Clear();
            foreach (Produto produto in itens)
            {
                if (produto.IsSelected)
                    prodselecionado.Add(produto);
            }


            dateGrid_produtos_selecionados.ItemsSource = null;
            dateGrid_produtos_selecionados.ItemsSource = prodselecionado;

            
            foreach (Produto produto in itens)
            {
                if (produto.IsSelected)
                {
                    valor = produto.Quantidade;
                    valor = valor * produto.Preco;

                }
                    
            }

            LoadPreco();


            if (prodselecionado.Count == 0)
                MessageBox.Show("Nenhum produto foi selecionado!", "", MessageBoxButton.OK, MessageBoxImage.Information);




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var text = txtFilter.Text;
            var filterlist = prodList.Where(i => i.Nome.ToLower().Contains(text));
            filterprodutos.ItemsSource = filterlist;

        }

        private void lbl_preco_TextChanged(object sender, TextChangedEventArgs e)
        {
          
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

        private void LoadPreco()
        {
            lbl_preco.Text = Convert.ToString(valor);

            
        }

        private void dateGrid_produtos_selecionados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void filterprodutos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtnomefunc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
