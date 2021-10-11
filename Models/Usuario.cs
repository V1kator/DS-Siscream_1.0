using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siscream.Models
{
    class Usuario
    {
        public int Id { get; set; }

        public string UsuarioCPF { get; set; }

        public string Senha {private get; set; }


        private static Usuario _instance;

        private Usuario() { }

        public static Usuario GetInstance()
        {
            if (_instance == null)
                _instance = new Usuario();
            return _instance;
        }

        public static bool Login(string usuario, string senha)
        {
            var user = new Usuario_DAO().GetByUsuario(usuario, senha);

            if (user != null)
                return true;

            return false;
        }
    }
}
