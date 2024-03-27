using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Usuario
    {
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nome_completo")]
        public string? NomeCompleto { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("senha")]
        public int Senha { get; set; }
        [Column("telefone")]
        public int Telefone { get; set; }
        [Column("perfil")]
        public string? Perfil { get; set; }
        [Column("status")]
        public string? Status { get; set; }
    }
}
