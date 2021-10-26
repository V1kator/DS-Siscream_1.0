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
                    funcionario.Codigo_end = reader.GetInt32("cod_end_fk");
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
                query.CommandText = "INSERT INTO tb_funcionario (nome_func, cpf_func, cargo_func, tipoContrato_func, senha_func, dataAdmissao_func, cod_end_fk, sexo_func, nascimento_func, email_func, telefone_func, rg_func, cod_end_fk) " +
                                    "VALUES (@nome, @cpf, @cargo, @contrato, @senha, @admissao, @codigo_end, @sexo, @nascimento, @email, @telefone, @rg, @endereco)";

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
                query.Parameters.AddWithValue("@enderco", id_end);


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
