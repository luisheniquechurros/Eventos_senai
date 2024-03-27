using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace senai_eventos_api.Models
{
    public class Ingresso
    {
        [Column("id_ingresso")]
        public int IdIngresso {get; set;}

        [Column("valor")]
        public string? Valor {get; set;}

        [Column("status")]
        public string? Status {get; set;}

        [Column("tipo")]
        public string? Tipo {get; set;}

        [Column("codigo_qr")]
        public string? CodigoQr {get; set;}

        [Column("data_utilizacao")]
        public DateTime DataUtilizacao {get; set;}

    }
}