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

namespace Siscream
{
    /// <summary>
    /// Lógica interna para Consultar_Cliente.xaml
    /// </summary>
    public partial class Consultar_Cliente : Window
    {
        public Consultar_Cliente()
        {
            InitializeComponent();
            Loaded += Consultar_Cliente_Loaded;
        }

        private void Consultar_Cliente_Loaded(object sender, RoutedEventArgs e)
        {
            List<Consultar_Cliente_Teste> Consult_Cli = new List<Consultar_Cliente_Teste>();

            for(int i=0; i<37; i++)
            {
                Consult_Cli.Add(new Consultar_Cliente_Teste()
                {
                    Id = i+1,
                    Nome = "Empresa "+(1+i),
                    CNPJ = 15 * 150* i
                });
            }
           
            Datagrid_consulta_cliente.ItemsSource = Consult_Cli;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
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
