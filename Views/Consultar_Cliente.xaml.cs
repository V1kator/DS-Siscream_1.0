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
    /// Lógica interna para Consultar_Cliente.xaml
    /// </summary>
    public partial class Consultar_Cliente : Window
    {

        private List<Cliente> clienteList = new List<Cliente>();

        public Consultar_Cliente()
        {
            InitializeComponent();
            Loaded += Consultar_Cliente_Loaded;
        }

        private void Consultar_Cliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                clienteList = new Cliente_DAO().List();
                Datagrid_consulta_cliente.ItemsSource = clienteList;


                //var dao = new Produto_DAO();
                //datagrid_consulta.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bnt_consultar_cliente_interno_Click(object sender, RoutedEventArgs e)
        {
            var text = Textbox_consultar_cliente.Text;
            var filteredList = clienteList.Where(i => i.Nome.ToLower().Contains(text));
            Datagrid_consulta_cliente.ItemsSource = filteredList;
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

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PopUp_Funcao_Disponivel_Futuramente fun_di_futu = new PopUp_Funcao_Disponivel_Futuramente();
            fun_di_futu.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PopUp_excluir_cliente_consulta exc_cli_con = new PopUp_excluir_cliente_consulta();
            exc_cli_con.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PopUp_Funcao_Disponivel_Futuramente fun_di_futu = new PopUp_Funcao_Disponivel_Futuramente();
            fun_di_futu.ShowDialog();
        }
    }
}
