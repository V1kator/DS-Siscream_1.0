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
                var id_end = new Endereco_DAO().InsertEnd(t.End);


                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_cliente (nome_cli, cnpj_cli, email_cli, inscricao_cli, celular_cli, telefone_cli, cod_end_fk) " +
                                    "VALUES (@nome, @cnpj, @email, @inscricao, @celular, @telefone, @endereco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@inscricao", t.Inscricao);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@endereco", id_end);


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
                query.CommandText = "SELECT * FROM tb_cliente LEFT JOIN tb_endereco ON cod_end = cod_end_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var cli = new Cliente()
                    {
                        Codigo = reader.GetInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        Cnpj = reader.GetString("cnpj_cli"),
                        Email = reader.GetString("email_cli"),
                        Inscricao = reader.GetString("inscricao_cli"),
                        Celular = reader.GetString("celular_cli"),
                        Telefone = reader.GetString("telefone_cli"),
                    };
                    if (!reader.IsDBNull(reader.GetOrdinal("cod_end_fk")))
                    {
                        cli.End.Codigo = reader.GetInt32("cod_end");
                        cli.End.Cidade = reader.GetString("cidade_end");
                    }
                    list.Add(cli);

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

