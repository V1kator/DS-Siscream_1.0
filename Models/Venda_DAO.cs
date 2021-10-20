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
    class Venda_DAO : IDAO<Venda>
    {
        private static Conexao conn;


        public Venda_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(Venda t)
        {
            throw new NotImplementedException();
        }

        public Venda GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Venda t)
        {
            throw new NotImplementedException();
        }

        public List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_venda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {

                        Codigo = reader.GetInt32("cod_venda"),
                        Valor = reader.GetFloat("valor_venda"),
                        Pagamento = reader.GetString("formaPagamento_venda"),
                        Data = reader.GetDateTime("data_venda"),
                        Caixa = reader.GetInt32("cod_caixa_fk")


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

        public void Update(Venda t)
        {
            throw new NotImplementedException();
        }
    }
}
