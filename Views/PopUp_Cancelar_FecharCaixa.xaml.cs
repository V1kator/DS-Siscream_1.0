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
    /// Lógica interna para PopUp_Cancelar_FecharCaixa.xaml
    /// </summary>
    public partial class PopUp_Cancelar_FecharCaixa : Window
    {
        public PopUp_Cancelar_FecharCaixa()
        {
            InitializeComponent();
        }
                

        private void Button_Click_F1(object sender, RoutedEventArgs e)
        {
            Tela_Menu tela = new Tela_Menu();
            tela.ShowDialog();
            this.Close();
        }

        private void Button_Click_F2(object sender, RoutedEventArgs e)
        {
            Fechar_Caixa tela = new Fechar_Caixa();
            tela.ShowDialog();
            
        }
    }
}
