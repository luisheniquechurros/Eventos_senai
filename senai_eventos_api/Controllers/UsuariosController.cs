using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using senai_eventos_api.DAO;

namespace senai_eventos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosDAO _usuarioDAO;

        public UsuariosController()
        {
            _usuarioDAO = new UsuariosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioDAO.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var usuario = _usuarioDAO.GetId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            _usuarioDAO.CriarUsuario(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            if (_usuarioDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _usuarioDAO.AtualizarUsuario(id, usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            if (_usuarioDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _usuarioDAO.DeletarUsuario(id);
            return Ok();
        }
    }
}