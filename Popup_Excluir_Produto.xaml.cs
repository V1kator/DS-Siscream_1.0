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
    /// Lógica interna para Popup_Excluir_Produto.xaml
    /// </summary>
    public partial class Popup_Excluir_Produto : Window
    {
        public Popup_Excluir_Produto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
=======
            Tela_Menu tela = new Tela_Menu();
            tela.ShowDialog();
>>>>>>> main
            this.Close();
        }
    }
}