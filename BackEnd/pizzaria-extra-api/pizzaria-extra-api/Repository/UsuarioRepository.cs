using Microsoft.EntityFrameworkCore;
using pizzaria_extra_api.Domains;
using pizzaria_extra_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaria_extra_api.Repository
{
    public class UsuarioRepository : IUsuarios
    {
        public Usuarios BuscarPorEmailSenha(string nome, string senha)
        {
            using (PizzariaContext ctx = new PizzariaContext())
            {
                return ctx.Usuarios.Include(i => i.TipoUsuarioNavigation).First(i => i.NomeUsuario == nome && i.Senha == senha);
            }
        }
    }
}
