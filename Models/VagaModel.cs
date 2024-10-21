﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models
{
    public class VagaModel
    {
        [Key]
        public int idVaga { get; set; }

        [Required]
        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }
        public string nomeVaga { get; set; } = string.Empty;
        public string descricaoVaga { get; set; } = string.Empty;


        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [JsonIgnore]
        [NotMapped]
        public CorporacaoModel? Corporacao { get; set; }


    }
}
