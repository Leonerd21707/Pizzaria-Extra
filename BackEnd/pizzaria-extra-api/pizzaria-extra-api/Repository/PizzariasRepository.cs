using Microsoft.EntityFrameworkCore;
using pizzaria_extra_api.Domains;
using pizzaria_extra_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaria_extra_api.Repository
{
    public class PizzariasRepository : IPizzarias
    {
        public void Cadastrar(Pizzarias pizzaria)
        {
            using (PizzariaContext ctx = new PizzariaContext())
            {
                ctx.Add(pizzaria);
                ctx.SaveChanges();
            }
        }

        public List<Pizzarias> Listar()
        {
            using (PizzariaContext ctx = new PizzariaContext())
            {
                return ctx.Pizzarias.ToList();
            }
        }

        public List<Pizzarias> ListarComCategoria()
        {
            using (PizzariaContext ctx = new PizzariaContext())
            {
                return ctx.Pizzarias.Include(o => o.IdCategoriaNavigation).ToList();
            }
        }
    }
}
