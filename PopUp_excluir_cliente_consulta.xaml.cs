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
    /// Lógica interna para PopUp_excluir_cliente_consulta.xaml
    /// </summary>
    public partial class PopUp_excluir_cliente_consulta : Window
    {
        public PopUp_excluir_cliente_consulta()
        {
            InitializeComponent();
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
            this.Close();
        }
    }
}
