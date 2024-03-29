﻿using System;
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
    /// Lógica interna para Cadastrar_Funcionario.xaml
    /// </summary>
    public partial class Cadastrar_Funcionario : Window
    {
        public Cadastrar_Funcionario()
        {
            InitializeComponent();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos submenu_produtos = new SubMenu_Produtos();
            submenu_produtos.ShowDialog();
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

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
        }

        private void btn_cadastrar_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                Funcionario funcionario = new Funcionario();

                funcionario.Nome = lbl_nome.Text;
                funcionario.Cpf = lbl_cpf.Text;
                funcionario.Rg = lbl_rg.Text;
                funcionario.Sexo = lbl_sexo.Text;
                funcionario.Cargo = lbl_cargo.Text;
                funcionario.Nascimento = (DateTime)lbl_nascimento.SelectedDate;
                funcionario.Contrato = lbl_contrato.Text;
                funcionario.Senha = lbl_senha.Password;
                funcionario.Salario = Convert.ToDouble(lbl_salario.Text);
                funcionario.Email = lbl_email.Text;
                funcionario.Admissao = (DateTime)lbl_admissao.SelectedDate;
                funcionario.Telefone = lbl_telefone.Text;
                funcionario.End.Logradouro = lbl_rua.Text;       
                funcionario.End.Bairro = lbl_bairro.Text;
                funcionario.End.Cidade = lbl_cidade.Text;
                funcionario.End.Cep = lbl_cep.Text;
                funcionario.End.Uf = lbl_uf.Text;
                funcionario.End.Numero = lbl_numero.Text;


                Funcionario_DAO funcionario_DAO = new Funcionario_DAO();
                funcionario_DAO.Insert(funcionario);

                MessageBox.Show("Funcionario adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            /*Popup_Cadastrar_Funcionario popup = new Popup_Cadastrar_Funcionario();
            popup.ShowDialog();*/

        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Cancelar_Funcionario popup = new Popup_Cancelar_Funcionario();
            popup.ShowDialog();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Funcionario consultar_func = new Popup_Editar_Funcionario();
            consultar_func.ShowDialog();
        }

        private void btn_demitir_Click(object sender, RoutedEventArgs e)
        {
            Popup_Demitir_Funcionario popup = new Popup_Demitir_Funcionario();
            popup.ShowDialog();
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void lbl_sexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbl_nome_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_salario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_cargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbl_id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_id_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_cep_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
