using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBase;

namespace Siscream.Models
{
    class LancarGastos_DAO : IDAO<LancarGastos>
    {


        private static Conexao conn;


        public LancarGastos_DAO()
        {
            conn = new Conexao();
        }

        public void Delete(LancarGastos t)
        {
            throw new NotImplementedException();
        }

        public LancarGastos GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(LancarGastos t)
        {
            /*
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tb_gasto (Descricao_gas, valor_gas, data_gas) " +
                "VALUES (@Desc_gast, @val_gast, @data_gast)";

                query.Parameters.AddWithValue("@Desc_gast", t.Descricao_gas);
                query.Parameters.AddWithValue("@val_gast", t.valor_gas);
                query.Parameters.AddWithValue("@data_gast", t.data_gas);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            } 
            */
        }

        public List<LancarGastos> List()
        {
            throw new NotImplementedException();
        }

        public void Update(LancarGastos t)
        {
            throw new NotImplementedException();
        }
    }
}
