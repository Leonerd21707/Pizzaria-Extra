using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaria_extra_api.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira o nome do usuário")]
        public string NomeUsuario{ get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário")]
        public string Senha{ get; set; }
    }
}
