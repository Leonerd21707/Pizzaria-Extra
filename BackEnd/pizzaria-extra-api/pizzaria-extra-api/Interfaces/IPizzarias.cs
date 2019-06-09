using pizzaria_extra_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaria_extra_api.Interfaces
{
    public interface IPizzarias
    {
        List<Pizzarias> Listar();
        List<Pizzarias> ListarComCategoria();
        void Cadastrar(Pizzarias pizzaria);
    }
}
