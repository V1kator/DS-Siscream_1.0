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

namespace Siscream.Views
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
            try
            {
                LancarGastos lancargastos = new LancarGastos();

                lancargastos.valor = Convert.ToDouble(gasto.Text);
                lancargastos.Descricao = produto.Text;
                lancargastos.data = (DateTime)data.SelectedDate;

                LancarGastos_DAO lancargastos_DAO = new LancarGastos_DAO();
                lancargastos_DAO.Insert(lancargastos);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro de execução", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
