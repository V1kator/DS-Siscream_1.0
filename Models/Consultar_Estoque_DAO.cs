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

                        Id = reader.GetInt32("cod_prod"),
                        Nome = reader.GetString("nome_prod"),
                        Unidade = reader.GetString("unidademed_prod"),
                        Validade = reader.GetDateTime("datavalidade_prod"),
                        Tipo = reader.GetString("tipo_prod"),
                        Estoque = reader.GetInt32("estoque_prod"),
                        Fabricante = reader.GetString("fabricante_prod"),
                        Marca = reader.GetString("marca_prod"),
                        Barras = reader.GetString("codbarras_prod"),
                        Comissao = reader.GetInt32("comissao_prod"),
                        Preco = reader.GetFloat("preco_prod"),
                        Custo = reader.GetFloat("custo_prod"),
                        Descricao = reader.GetString("descricao_prod"),

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
