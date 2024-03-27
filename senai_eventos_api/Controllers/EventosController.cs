using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using senai_eventos_api.DAO;
using senai_eventos_api.Models;

namespace senai_eventos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private EventosDAO _eventosDAO;

        public EventosController()
        {
            _eventosDAO = new EventosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var eventos = _eventosDAO.GetAll();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var evento = _eventosDAO.GetId(id);
            if(evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult CriarEvento(Eventos evento)
        {
            _eventosDAO.CriarEvento(evento);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult AtualizarEvento(int id, Eventos evento)
        {
            if(_eventosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _eventosDAO.AtualizarEvento(id, evento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEvento(int id)
        {
            if(_eventosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _eventosDAO.DeletarEvento(id);
            return Ok();
        }
    }
}
