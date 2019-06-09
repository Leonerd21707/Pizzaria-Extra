using System;
using System.Collections.Generic;

namespace pizzaria_extra_api.Domains
{
    public partial class Pizzarias
    {
        public int IdPizzaria { get; set; }
        public string NomePizzaria { get; set; }
        public int IdCategoria { get; set; }
        public string Telefone { get; set; }
        public bool OpcaoVegana { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
    }
}
