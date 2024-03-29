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
    /// Lógica interna para Cadastrar_Produto.xaml
    /// </summary>
    public partial class Cadastrar_Produto : Window
    {
        public Cadastrar_Produto()
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

        private void LoadProd()
        {
            try
            {
                Produto produto = new Produto();
                produto.Nome = lbl_nome.Text;
                produto.Unidade = lbl_unidademed.Text;
                produto.Validade = (DateTime)lbl_datavalidade.SelectedDate;
                produto.Tipo = lbl_tipo.Text;
                produto.Estoque = Convert.ToInt32(lbl_estoque.Text);
                produto.Fabricante = lbl_fabricante.Text;
                produto.Marca = lbl_marca.Text;
                produto.Barras = lbl_codbarras.Text;
                produto.Comissao = Convert.ToInt32(lbl_comissao.Text);
                produto.Preco = Convert.ToDouble(lbl_preco.Text);
                produto.Custo = Convert.ToDouble(lbl_custo.Text);
                produto.Descricao = lbl_descricao.Text;


                Produto_DAO produto_DAO = new Produto_DAO();
                produto_DAO.Insert(produto);

                Popup_Cadastrar_Produto popup = new Popup_Cadastrar_Produto();
                popup.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
        

        private void btn_cadastros_Click(object sender, RoutedEventArgs e)
        {

            Popup_Cadastrar_Produto popup = new Popup_Cadastrar_Produto();
            popup.ShowDialog();

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

        private void btn_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            LoadProd();
            
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Popup_Editar_Produto popup = new Popup_Editar_Produto();
            popup.ShowDialog();
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            Popup_Excluir_Produto popup = new Popup_Excluir_Produto();
            popup.ShowDialog();
           
        }

        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void lbl_nome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
