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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Siscream.Models;


namespace Siscream.Views
{
    /// <summary>
    /// Interação lógica para Consultar_Funcionario.xam
    /// </summary>
    public partial class Consultar_Funcionario : Window

    {
        private List<Funcionario> funcionariolist = new List<Funcionario>();

        public Consultar_Funcionario()
        {
            InitializeComponent();
            Loaded += Consultar_Funcionario_Loaded;
        }

        private void Consultar_Funcionario_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                funcionariolist = new Funcionario_DAO().List();
                Datagrid_consulta_func.ItemsSource = funcionariolist;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void bnt_excluir_funcionarii_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelected = Datagrid_consulta_func.SelectedItem as Funcionario;

            var result = MessageBox.Show($"Deseja realmente excluir o funcionario'{funcionarioSelected.Nome}'?", "Confirmação de Exclusão",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {


                if (result == MessageBoxResult.Yes)
                {
                    var dao = new Funcionario_DAO();
                    dao.Delete(funcionarioSelected);
                    LoadList();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exeção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void bnt_consultar_funcionario_interno_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
