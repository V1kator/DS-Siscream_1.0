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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Siscream.Models;
using FluentValidation;
using MySql.Data.MySqlClient;
using Siscream.Interfaces;
using Siscream.DataBase;
using Siscream.Views;

namespace Siscream
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            _ = text_cpf_login.Focus();

            try
            {
                var conexao = new Conexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            var main = new Tela_Menu();
            main.Show();
            this.Close();
        }


        /*private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = text_cpf_login.Text;
            string senha = text_senha_login.Password.ToString();

            if (Usuario.Login(usuario, senha))
            {
                var main = new Tela_Menu();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("CPF e/ou senha incorretos, por favor tente novamente!","Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                _ = text_cpf_login.Focus();


            }
        }*/

    }
}

