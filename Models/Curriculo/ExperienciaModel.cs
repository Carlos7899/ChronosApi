﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models.Curriculo
{
    public class ExperienciaModel
    {
        [Key]
        public int idExperiencia { get; set; }
        [ForeignKey("idCurriculo")]
        public int idCurriculo { get; set; }
        public string cargoExperiencia { get; set; }
        public string empresaExperiencia { get; set; }
        public DateTime dataInicioExperiencia { get; set; }
        public DateTime? dataFimExperiencia { get; set; }
        public string Descricao { get; set; }


        [NotMapped]
        [JsonIgnore]
        public CurriculoModel? Curriculo { get; set; }
    }
}
