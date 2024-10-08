﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronosApi.Models
{
    public class CursoModel
    {
        [Key]
        public int idCurso { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }

        [ForeignKey("idCorporacaoEndereco")]
        public int idCorporacaoEndereco { get; set; }
        public string nomeCurso { get; set; } = string.Empty;
        public string descricaoCurso { get; set; } = string.Empty;




    }
}
