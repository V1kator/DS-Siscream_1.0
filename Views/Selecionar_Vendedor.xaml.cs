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
using Siscream.DataBase;
using MySql.Data.MySqlClient;


namespace Siscream.Views
{
    /// <summary>
    /// Lógica interna para Selecionar_Vendedor.xaml
    /// </summary>
    public partial class Selecionar_Vendedor : Window
    {
        public Selecionar_Vendedor()
        {
            InitializeComponent();
            Loaded += Selecionar_Vendedor_Loaded;
        }

        private void Selecionar_Vendedor_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBox();
        }

        private void Button_Iniciar_Click(object sender, RoutedEventArgs e)
        {
            Iniciar_Venda selectVend = new Iniciar_Venda();
            selectVend.ShowDialog();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
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

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadComboBox()
        {
            try
            {
                CBFuncionario.ItemsSource = new Funcionario_DAO().List();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
