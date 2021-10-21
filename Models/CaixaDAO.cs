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
