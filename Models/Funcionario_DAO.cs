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
    class Funcionario_DAO : IDAO<Funcionario>
    {

        private static Conexao conn;


        public Funcionario_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(Funcionario t)
        {
            throw new NotImplementedException();
        }

        public Funcionario GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_funcionario (nome_func, cpf_func, cargo_func, tipoContrato_func, senha_func, dataAdmissao_func, cod_end_fk, sexo_func, nascimento_func, email_func, telefone_func, rg_func) " +
                                    "VALUES (@nome, @cpf, @cargo, @contrato, @senha, @admissao, @codigo_end, @sexo, @nascimento, @email, @telefone, @rg)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cargo", t.Cargo);
                query.Parameters.AddWithValue("@contrato", t.Contrato);
                query.Parameters.AddWithValue("@senha", t.Senha);
                query.Parameters.AddWithValue("@admissao", t.Admissao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@codigo_end", t.Codigo_end);
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@nascimento", t.Nascimento);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@rg", t.Rg);


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

        public List<Funcionario> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionario t)
        {
            throw new NotImplementedException();
        }
    }
}
