using System;
using System.Collections.Generic;

namespace pizzaria_extra_api.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Pizzarias = new HashSet<Pizzarias>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public ICollection<Pizzarias> Pizzarias { get; set; }
    }
}
