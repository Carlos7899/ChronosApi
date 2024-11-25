﻿using ChronosApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class CandidaturaModel
    {
        [Key]
        public int idCandidatura { get; set; }

        [ForeignKey("idEgresso")]
        public int idEgresso { get; set; }

        [ForeignKey("idVaga")]
        public int idVaga { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }

        public DateTime dataIncricao { get; set; }
        public StatusCandidatura? Status { get; set; } 
        public DateTime? DataAtualizacao { get; set; }
        public string? Notas { get; set; }
        public string? Feedback { get; set; }
    }
}
