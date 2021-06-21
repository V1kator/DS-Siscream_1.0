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
    /// Lógica interna para LancarGastprod.xaml
    /// </summary>
    public partial class LancarGastprod : Window
    {
        public LancarGastprod()
        {
            InitializeComponent();
        }

        private void botao_confim_Click(object sender, RoutedEventArgs e)
        {
            PopUp_AdicionarGastProd adg = new PopUp_AdicionarGastProd();
            adg.ShowDialog();
            this.Close();
        }

        private void botao_cancelr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
