using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBase;


namespace Siscream.Models
{
    class Produto_DAO : IDAO<Produto>
    {
        private static Conexao conn;


        public Produto_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(Produto t)
        {
            throw new NotImplementedException();
        }

        public Produto GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_produto (nome_prod, unidademed_prod, datavalidade_prod, tipo_prod, estoque_prod, fabricante_prod, marca_prod, codbarras_prod, comissao_prod, preco_prod, custo_prod, descricao_prod) " +
                                    "VALUES (@nome, @unidade, @validade, @tipo, @estoque, @fabricante, @marca, @barras, @comissao, @preco, @custo, @descricao)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@unidade", t.Unidade);
                query.Parameters.AddWithValue("@validade", t.Validade);
                query.Parameters.AddWithValue("@tipo", t.Tipo);
                query.Parameters.AddWithValue("@estoque", t.Estoque);
                query.Parameters.AddWithValue("@fabricante", t.Fabricante);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@barras", t.Barras);
                query.Parameters.AddWithValue("@comissao", t.Comissao);
                query.Parameters.AddWithValue("@preco", t.Preco);
                query.Parameters.AddWithValue("@custo", t.Custo);
                query.Parameters.AddWithValue("@descricao", t.Descricao);


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

        public List<Produto> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Produto t)
        {
            throw new NotImplementedException();
        }
    }

}
