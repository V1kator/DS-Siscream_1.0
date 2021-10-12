using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBese;


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
            throw new NotImplementedException();
        }

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }

    }

}

