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
    class CaixaDAO : IDAO<Caixa> 
    {
        private static Conexao conn;

        public CaixaDAO(){

            conn = new Conexao();

        }

        public void AbrirCaixa(Caixa t)
        {
           try
            {
                var query = conn.Query();

                query.CommandText = "INSERT INTO tb_caixa (funcionario_caixa, valorAbertura_caixa, data_abt" +
                                    "VALUES (@nome_func, @saldoInicial, @data)";

           
                query.Parameters.AddWithValue("@nome_func", t.Funcionario.Nome);
                query.Parameters.AddWithValue("@saldoInicial", t.saldoInicial);
                query.Parameters.AddWithValue("@data", t.data.ToString("yyyy-MM-dd"));

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente!");
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



        public void FecharCaixa(Caixa t) 
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_caixa (funcionario_caixa," +
                        "dinheiro_caixa, credito_caixa, debito_caixa, total_caixa, valor_retirado_caixa, especificacoes, saldofinal_caixa) " +
                        "VALUES (@nome_func, @dinheiroCX, @creditoCX, @debitoCX, @totalCX, @valorRetirado, @especif, @saldoFinal)";

               
                query.Parameters.AddWithValue("@nome_func", t.Funcionario.Nome);
                query.Parameters.AddWithValue("@dinheiroCX", t.dinheiroCX);
                query.Parameters.AddWithValue("@creditoCX", t.creditoCX);
                query.Parameters.AddWithValue("@debitoCX", t.debitoCX);
                query.Parameters.AddWithValue("@totalCX", t.totalCX);
                query.Parameters.AddWithValue("@valorRetirado", t.valorRetirado);
                query.Parameters.AddWithValue("@especif", t.especif);
                query.Parameters.AddWithValue("@saldoFinal", t.saldoFinal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente!");
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



        public void Delete(Caixa t)
        {
            throw new NotImplementedException();
        }


        public Caixa GetByID(int id)
        {
            throw new NotImplementedException();

        }


        public void Insert(Caixa t)
        {
            throw new NotImplementedException();
        }

        public List<Caixa> List()
        {
              try
              {

                  List<Caixa> list = new List<Caixa>();

                  var query = conn.Query();

                  query.CommandText = "SELECT funcionario_caixa FROM tb_caixa";

                  MySqlDataReader reader = query.ExecuteReader();

                  while (reader.Read())
                  {
                      var cx = new Caixa()
                      {


                      };

                      list.Add(cx);

                  }
                  return list;

              }
              catch (Exception e)
              {
                  throw e;
              }
        }



        public void Update(Caixa t)
        {
            throw new NotImplementedException();
        }


    }
}
