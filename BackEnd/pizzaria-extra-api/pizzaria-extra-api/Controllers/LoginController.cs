using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pizzaria_extra_api.Domains;
using pizzaria_extra_api.Interfaces;
using pizzaria_extra_api.Repository;
using pizzaria_extra_api.ViewModel;

namespace pizzaria_extra_api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUsuarios UsuarioRepository { get; set; }
        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuarios User = UsuarioRepository.BuscarPorEmailSenha(login.NomeUsuario, login.Senha);

                if (User == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Usuário não encontrado"
                    });
                }

                var claims = new[]
                {
                        new Claim(ClaimTypes.Name, User.NomeUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, User.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, User.TipoUsuarioNavigation.NomeTipoUsuario.ToString()),
                        new Claim("Role", User.TipoUsuarioNavigation.NomeTipoUsuario.ToString())
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Pizzaria-webapi-chave"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Pizzaria-webapi",
                    audience: "Pizzaria-webapi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}