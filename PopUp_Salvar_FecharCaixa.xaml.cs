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
    /// Lógica interna para PopUp_Salvar_FecharCaixa.xaml
    /// </summary>
    public partial class PopUp_Salvar_FecharCaixa : Window
    {
        public PopUp_Salvar_FecharCaixa()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tela_Menu tela = new Tela_Menu();
            tela.ShowDialog();
            this.Close();
        }
    }
}
