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
    /// Lógica interna para Popup_Venda_Realizada.xaml
    /// </summary>
    public partial class Popup_Venda_Realizada : Window
    {
        public Popup_Venda_Realizada()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            Selecionar_Vendedor Select = new Selecionar_Vendedor();
            Select.Show();
=======
<<<<<<< HEAD
>>>>>>> parent of 4aac66c... Revert "Atualizacao window 2"
            this.Close();
=======
            Iniciar_Venda iniciar = new Iniciar_Venda();
            iniciar.ShowDialog();
>>>>>>> main
        }
    }
}
