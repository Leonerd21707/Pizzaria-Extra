using System;
using System.Collections.Generic;

namespace pizzaria_extra_api.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
