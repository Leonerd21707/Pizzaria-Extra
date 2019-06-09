using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizzaria_extra_api.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Insira o nome do usuário")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Insira o tipo de usuário")]
        public int TipoUsuario { get; set; }

        public TiposUsuario TipoUsuarioNavigation { get; set; }
    }
}
