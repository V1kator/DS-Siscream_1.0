using System;
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
    class Endereco_DAO : IDAO<Endereco>
    {

        private static Conexao conn;


        public Endereco_DAO()
        {
            conn = new Conexao();
        }
        public void Delete(Endereco t)
        {
            throw new NotImplementedException();
        }

        public Endereco GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Endereco t)
        {
            throw new NotImplementedException();
        }

        public long InsertEnd(Endereco t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_endereco (logradouro_end, numero_end, bairro_end, cidade_end, uf_end, cep_end) " +
                                    "VALUES (@logradouro, @numero, @bairro, @cidade, @uf, @cep)";

                query.Parameters.AddWithValue("@logradouro", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@uf", t.Uf);
                query.Parameters.AddWithValue("@cep", t.Cep);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O endereço não foi salvo. Verifique e tente novamente.");

                long id = query.LastInsertedId;

                return id;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    

    public List<Endereco> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Endereco t)
        {
            throw new NotImplementedException();
        }
    }
}
