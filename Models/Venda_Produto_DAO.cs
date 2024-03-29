﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.Models;
using Siscream.DataBase;
using MySql.Data.MySqlClient;

namespace Siscream.Models
{
    public class Venda_Produto_DAO : IDAO<Venda_Produto>
    {
        private static Conexao conn;


        public Venda_Produto_DAO()
        {
            conn = new Conexao();
        }
        public void Delete(Venda_Produto t)
        {
            throw new NotImplementedException();
        }

        public Venda_Produto GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Venda_Produto t)
        {
            throw new NotImplementedException();
        }

        public List<Venda_Produto> _compraItensList()
        {
            try
            {
                List<Venda_Produto> _compraItensList = new List<Venda_Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_Venda_Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    var prod = new Produto();

                    _compraItensList.Add(new Venda_Produto()
                        {
                            Codigo = reader.GetInt32("cod_prodVenda"),
                            Quantidade = reader.GetInt32("quantidade_prodVenda"),
                            Valor = reader.GetDouble("valor_prodVenda"),
                            ValorTotal = reader.GetDouble("valorTotal_prodVenda")
                        });
                     
                }
                return _compraItensList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Venda_Produto t)
        {
            throw new NotImplementedException();
        }

        public List<Venda_Produto> List()
        {
            throw new NotImplementedException();
        }
    }
}
