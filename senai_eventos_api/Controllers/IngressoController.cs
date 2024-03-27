using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using senai_eventos_api.Models;
using senai_eventos_api.DAO;

namespace senai_eventos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngressoController : ControllerBase
    {
        private IngressoDAO _ingressoDAO;

        public IngressoController()
        {
            _ingressoDAO = new IngressoDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ingressos = _ingressoDAO.GetAll();
            return Ok(ingressos);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var ingresso = _ingressoDAO.GetId(id);
            if(ingresso == null){
                return NotFound();
            }
            return Ok(ingresso);
        }

        [HttpPost]
        public IActionResult CriarIngresso(Ingresso ingresso)
        {
            _ingressoDAO.CriarIngresso(ingresso);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult AtualizarIngresso(int id, Ingresso ingresso)
        {
            if(_ingressoDAO.GetId(id) == null){
                return NotFound();
            }
            _ingressoDAO.AtualizarIngresso(id, ingresso);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletarIngresso(int id)
        {
            if(_ingressoDAO.GetId(id) == null){
                NotFound();
            }
            _ingressoDAO.DeletarIngresso(id);
            return Ok();
        }
    }
}