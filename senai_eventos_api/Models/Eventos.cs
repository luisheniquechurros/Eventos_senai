    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    namespace senai_eventos_api.Models
    {
        public class Eventos
        {
            [Column("id_evento")]
            public int IdEvento {get; set;}

            [Column("total_ingressos")]
            public int TotalIngressos {get; set;}

            [Column("data_evento")]
            public DateTime DataEvento {get; set;}

            [Column("descricao")]
            public string? Descricao {get; set;}
        }
    }