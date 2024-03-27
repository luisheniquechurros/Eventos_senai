using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai_eventos_api.Models;
using Microsoft.AspNetCore.Mvc;
using senai_eventos_api.DAO;
using static senai_eventos_api.Models.Pedidos;

namespace senai_eventos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private PedidoDAO _pedidoDAO;

        public PedidoController()
        {
            _pedidoDAO = new PedidoDAO();
        }

        [HttpGet]

        public IActionResult Get()
        {
            var pedidos = _pedidoDAO.GetAll();
            return Ok(pedidos);
        }

        private object GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var pedidos = _pedidoDAO.GetId(id);
            if(pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpPost]
        public IActionResult CriarPedido(Pedido pedidos)
        {
            _pedidoDAO.CriarPedido(pedidos);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(int id, Pedido pedidos)
        {
            if(_pedidoDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _pedidoDAO.AtualizarPedido(id, pedidos);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPedido(int id)
        {
            if(_pedidoDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _pedidoDAO.DeletarPedido(id);
            return Ok();
        }
    }
}