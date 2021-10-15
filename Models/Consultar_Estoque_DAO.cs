using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBase;


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
