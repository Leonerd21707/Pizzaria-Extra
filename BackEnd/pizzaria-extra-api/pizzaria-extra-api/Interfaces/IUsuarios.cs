using pizzaria_extra_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaria_extra_api.Interfaces
{
    public interface IUsuarios
    {
        Usuarios BuscarPorEmailSenha(string nome, string senha);
    }
}
