using NetCore_WebApi_JWT_Swagger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_WebApi_JWT_Swagger.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly List<Usuario> UsuariosDb = new List<Usuario>() {
            new Usuario(){ Id = 1, Login = "Maria", Senha = "Senha_Gerente", Regra = "gerente"},
            new Usuario(){ Id = 2, Login = "Jose", Senha = "Senha_Funcionario", Regra = "funcionario"}

        };

        public Usuario Login(Usuario usuario)
        {
            Usuario usuarioLogado = UsuariosDb.FirstOrDefault(x => x.Login.ToLower() == usuario.Login.ToLower() 
            && x.Senha == usuario.Senha);

            return usuarioLogado;

        }

    }
}
