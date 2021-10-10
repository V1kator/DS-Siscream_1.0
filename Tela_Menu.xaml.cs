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
using Siscream.DataBese;
using Siscream.Models;

namespace Siscream
{
    /// <summary>
    /// Lógica interna para Tela_Menu.xaml
    /// </summary>
    public partial class Tela_Menu : Window
    {
        public Tela_Menu()
        {
            InitializeComponent();
        }

        private void Tela_Menu_loaded(object sender, RoutedEvent e)
        {
            try
            {
                var conexao = new Conexao();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos submenu_prod = new SubMenu_Produtos();
            submenu_prod.ShowDialog();
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

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cadastros_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Cadastros submenu_cadastros = new SubMenu_Cadastros();
            submenu_cadastros.ShowDialog();

            Insert_teste();

        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();

        }

        private void Insert_teste()
        {
            try
            {
                Funcionario Funcionario = new Funcionario();
                Funcionario.Nome = "Geraldo da Silva";
                Funcionario.Cpf = "045-653-586-89";
                Funcionario.Cargo = "Assitente de produção";
                Funcionario.Contrato = "Carteira assinada";
                Funcionario.Senha = "123456780;";
                Funcionario.Admissao = DateTime.Now;
                Funcionario.Codigo_end = 2;

                Funcionario_DAO funcionario_DAO = new Funcionario_DAO();
                funcionario_DAO.Insert(Funcionario);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }
    }
}
