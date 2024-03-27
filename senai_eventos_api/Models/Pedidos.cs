using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_eventos_api.Models
{
    public class Pedidos
    {
        public class Pedido
    {
        [Column("id_pedido")]
        public int IdPedido { get; set; } 

        [Column("data")]
        public DateTime Data {get; set;}

        [Column("total")]
        public int Total {get; set;}

        [Column("quantidade")]
        public int Quantidade {get;set;}

        [Column("forma_pagamento")]
        public string? FormaPagamento {get;set;}

        [Column("status")]
        public string? Status {get;set;}

        [Column("validacao_id_usuario")]
        public int ValidacaoId {get; set;}

        [Column("usuario_id_usuario")]
        public int UsuarioId { get; internal set; }

        internal static void Add(Pedido pedidos)
        {
            throw new NotImplementedException();
        }
    } 
    }
}