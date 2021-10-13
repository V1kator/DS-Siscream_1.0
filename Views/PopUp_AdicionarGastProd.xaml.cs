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

namespace Siscream.Views
{
    /// <summary>
    /// Lógica interna para PopUp_AdicionarGastProd.xaml
    /// </summary>
    public partial class PopUp_AdicionarGastProd : Window
    {
        public PopUp_AdicionarGastProd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
