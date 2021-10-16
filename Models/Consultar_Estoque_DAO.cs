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
    class Consultar_Estoque_DAO : IDAO<Consultar_Estoque>
    {

        private static Conexao conn;

        public Consultar_Estoque_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(Consultar_Estoque t)
        {
            throw new NotImplementedException();
        }

        public Consultar_Estoque GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Consultar_Estoque t)
        {
            throw new NotImplementedException();
        }

        public List<Consultar_Estoque> List()
        {
            try
            {
                List<Consultar_Estoque> list = new List<Consultar_Estoque>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Consultar_Estoque()
                    {

                        cod_prod = reader.GetInt32("cod_prod"),
                        nome_prod = reader.GetString("nome_prod"),
                        unidademed_prod = reader.GetString("unidademed_prod"),
                        datavalidade_prod = reader.GetDateTime("datavalidade_prod"),
                        tipo_prod = reader.GetString("tipo_prod"),
                        estoque_prod = reader.GetInt32("estoque_prod"),
                        fabricante_prod = reader.GetString("fabricante_prod"),
                        marca_prod = reader.GetString("marca_prod"),
                        codbarras_prod = reader.GetString("codbarras_prod"),
                        comissao_prod = reader.GetInt32("comissao_prod"),
                        preco_prod = reader.GetFloat("preco_prod"),
                        custo_prod = reader.GetFloat("custo_prod"),
                        descricao_prod = reader.GetString("descricao_prod"),

                    });
                }

                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Consultar_Estoque t)
        {
            throw new NotImplementedException();
        }
    }
}
