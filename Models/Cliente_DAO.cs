using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBase;
using MySql.Data.MySqlClient;



namespace Siscream.Models
{
    class Cliente_DAO : IDAO<Cliente>
    {
        private static Conexao conn;


        public Cliente_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public Cliente GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_cliente (nome_cli, cpf_cli, cnpj_cli, tipo_pessoa_cli, cod_end_fk) " +
                                    "VALUES (@nome, @cpf, @cnpj, @tipopessoa, @endereco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@tipopessoa", t.Tipo);
                query.Parameters.AddWithValue("@endereco", t.Endereco);


                var result = query.ExecuteNonQuery();

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

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {

                        Id = reader.GetInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        Cpf = reader.GetString("cpf_cli"),
                        Cnpj = reader.GetString("cnpj_cli"),
                        Tipo = reader.GetString("tipo_pessoa_cli"),
                        Endereco = reader.GetInt32("cod_end_fk"),
                       

                    });
                }

                return list;
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
    

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }

    }

}

