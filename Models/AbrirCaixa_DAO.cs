using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siscream.Interfaces;
using Siscream.DataBase;

namespace Siscream.Models
{
    class AbrirCaixa_Dao : IDAO<AbrirCaixa>
    {

        private static Conexao conn;


        public AbrirCaixa_Dao()
        {
            conn = new Conexao();
        }

        public void Delete(AbrirCaixa t)
        {
            throw new NotImplementedException();
        }

        public AbrirCaixa GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AbrirCaixa t)
        {
            throw new NotImplementedException();
        }

        public List<AbrirCaixa> List()
        {
            throw new NotImplementedException();
        }

        public void Update(AbrirCaixa t)
        {
            throw new NotImplementedException();
        }
    }
}
