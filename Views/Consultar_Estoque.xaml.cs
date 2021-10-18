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
    /// Lógica interna para Consultar_Estoque.xaml
    /// </summary>
    public partial class Consultar_Estoque : Window
    {

        private List<Consultar_Estoque> produtosList = new List<Consultar_Estoque>();
        List<Consultar_Estoque> list = new List<Consultar_Estoque>();

        public Consultar_Estoque()
        {
            InitializeComponent();
            Loaded += Consultar_Estoque_Loaded;
        }

        private void Consultar_Estoque_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();


        }

        private void LoadList()
        {
            try
            {

                var dao = new Consultar_Estoque_DAO();
               
                datagrid_consulta.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        private void bnt_consultar_estoque_interno_Click(object sender, RoutedEventArgs e)
        {

        }







        private void btn_produtos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Produtos produto = new SubMenu_Produtos();
            produto.ShowDialog();
            this.Close();
        }

        private void btn_vendas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Vendas submenu_vendas = new SubMenu_Vendas();
            submenu_vendas.ShowDialog();
        }

        private void btn_gastos_Click(object sender, RoutedEventArgs e)
        {
            SubMenu_Gastos submenu_gastos = new SubMenu_Gastos();
            submenu_gastos.ShowDialog();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Funcao_Disponivel_Futuramente fun_disp_futur = new PopUp_Funcao_Disponivel_Futuramente();
            fun_disp_futur.ShowDialog();
        }

       

        
    }
}
