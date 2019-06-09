using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzaria_extra_api.Domains;
using pizzaria_extra_api.Interfaces;
using pizzaria_extra_api.Repository;

namespace pizzaria_extra_api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PizzariasController : ControllerBase
    {
        public IPizzarias PizzariasRepository { get; set; }
        public PizzariasController()
        {
            PizzariasRepository = new PizzariasRepository();
        }

        //lista as pizzarias
        //todos podem listar
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                return Ok(PizzariasRepository.Listar());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet("categorias")]
        public IActionResult GetComCategoria()
        {
            try
            {
                return Ok(PizzariasRepository.ListarComCategoria());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        //Faz o cadastro uma pizzaria
        //Só o admin pode cadastrar
        [Authorize(Roles = "Administrador")]
        [HttpPost("cadastro")]
        public IActionResult Post(Pizzarias pizzaria)
        {
            try
            {
                PizzariasRepository.Cadastrar(pizzaria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}