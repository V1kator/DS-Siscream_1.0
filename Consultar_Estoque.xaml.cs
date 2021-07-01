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
    /// Lógica interna para Consultar_Estoque.xaml
    /// </summary>
    public partial class Consultar_Estoque : Window
    {
        public Consultar_Estoque()
        {
            InitializeComponent();
            Loaded += Consultar_Estoque_Loaded;
        }

        private void Consultar_Estoque_Loaded(object sender, RoutedEventArgs e)
        {
            List<Estoque_teste> listaprodutos_consulta = new List<Estoque_teste>();

            for (int i = 0; i < 25; i++) 
            {
                listaprodutos_consulta.Add(new Estoque_teste()
                {
                    Id = 1+i,
                    Nome = "Açai "+(i+1),
                    Preco = 22.90*(i+1),
                    Marca = "Indiana Jones "+(i+1),
                    Quantidade = 1*(i+1)

                });
            }
            
            datagrid_consulta.ItemsSource = listaprodutos_consulta;
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
            PopUp_Funcao_Disponivel_Futuramente fun_disp_futur = new PopUp_Funcao_Disponivel_Futuramente();
            fun_disp_futur.ShowDialog();
        }

        private void bnt_consultar_estoque_interno_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Funcao_Disponivel_Futuramente fun_disp_futur = new PopUp_Funcao_Disponivel_Futuramente();
            fun_disp_futur.ShowDialog();
        }

        
    }
}
