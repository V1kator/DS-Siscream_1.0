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
            try
            {

                var query = conn.Query();
                query.CommandText = "SELECT* FROM tb_funcionario WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.Codigo = reader.GetInt32("cod_func");
                    funcionario.Nome = reader.GetString("nome_func");
                    funcionario.Cpf = reader.GetString("cpf_func");
                    funcionario.Rg = reader.GetString("rg_func");
                    funcionario.Nascimento = reader.GetDateTime("nascimento_func");
                    funcionario.Senha = reader.GetString("senha_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Sexo = reader.GetString("sexo_func");
                    funcionario.Telefone = reader.GetString("telefone_func");
                    funcionario.Cargo = reader.GetString("cargo_func");
                    funcionario.Admissao = reader.GetDateTime("dataAdmissao_func");
                    funcionario.Contrato = reader.GetString("tipoContrato_func");
                }


                return funcionario;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var id_end = new Endereco_DAO().InsertEnd(t.End);

                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_funcionario (nome_func, cpf_func, cargo_func, tipoContrato_func, senha_func, dataAdmissao_func, sexo_func, nascimento_func, salario_func,email_func, telefone_func, rg_func, cod_end_fk) " +
                                    "VALUES (@nome, @cpf, @cargo, @contrato, @senha, @admissao, @sexo, @nascimento, @salario, @email, @telefone, @rg, @endereco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cargo", t.Cargo);
                query.Parameters.AddWithValue("@contrato", t.Contrato);
                query.Parameters.AddWithValue("@senha", t.Senha);
                query.Parameters.AddWithValue("@admissao", t.Admissao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@nascimento", t.Nascimento);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@rg", t.Rg);
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


        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_funcionario WHERE cargo_func ='atendente de caixa'";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        Codigo = reader.GetInt32("cod_func"),
                        Cpf = reader.GetString("cpf_func"),
                        Sexo = reader.GetString("sexo_func"),
                        Nascimento = reader.GetDateTime("nascimento_func"),
                        Telefone = reader.GetString("telefone_func"),
                        Email = reader.GetString("email_func"),
                        Rg = reader.GetString("rg_func"),
                        Contrato = reader.GetString("tipoContrato_func"),
                        Senha = reader.GetString("senha_func"),
                        Nome = reader.GetString("nome_func"),
                        Admissao = reader.GetDateTime("dataAdmissao_func")
                  
                    }) ;
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

        public void Update(Funcionario t)
        {
            throw new NotImplementedException();
        }
    }
}
