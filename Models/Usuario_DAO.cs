using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Siscream.Models
{
    class Usuario_DAO : Abstract_DAO<Usuario>
    {
        public Usuario GetByUsuario(string usuarioCPF, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM tb_login LEFT JOIN tb_funcionario ON cod_func = cod_func_fk WHERE cpf_func = @usuarioCPF AND senha_func = @senha";

                query.Parameters.AddWithValue("@usuarioCPF", usuarioCPF);
                query.Parameters.AddWithValue("@senha", senha);


                MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

               

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("cod_func");
                    usuario.UsuarioCPF = reader.GetString("cpf_func");

                }

                return usuario;
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
    }
}
