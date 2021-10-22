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

        public void FecharCaixa(Caixa t) 
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_caixa (funcionario_caixa, caixa_aberto, caixa_fechado, valorAbertura_caixa," +
                        "suprimento, dinheiro_caixa, credito_caixa, debito_caixa, total_caixa, valor_retirado_caixa, especificacoes, saldofinal_caixa) " +
                        "VALUES (@nome_func, @aberto, @fechado, @saldoInicial, @suprimento, @dinheiroCX, @creditoCX, @debitoCX, @totalCX, @valorRetirado, @especif, @saldoFinal)";

                query.Parameters.AddWithValue("@nome_func", t.nome_func);
                query.Parameters.AddWithValue("@aberto", t.aberto);
                query.Parameters.AddWithValue("@fechado", t.fechado);
                query.Parameters.AddWithValue("@saldoInicial", t.saldoInicial);
                query.Parameters.AddWithValue("@suprimento", t.suprimento);
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
            throw new NotImplementedException();
        }

        public void Update(Caixa t)
        {
            throw new NotImplementedException();
        }
    }
}
