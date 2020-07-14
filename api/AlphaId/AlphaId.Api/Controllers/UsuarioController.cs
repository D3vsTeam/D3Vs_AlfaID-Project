using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaId.Dominio.Entidades;
using AlphaId.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlphaId.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioServico usuarioServico;

        public UsuarioController()
        {
            usuarioServico = new UsuarioServico();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuarioServico.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ListarOperario()
        {
            try
            {
                var operarios = usuarioServico.ListarOperarios();
                return Ok(operarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LoginUsuario([FromQuery] string cpf, [FromQuery] string senha)
        {
            try
            {
                var usuario = usuarioServico.Login(cpf, senha);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
