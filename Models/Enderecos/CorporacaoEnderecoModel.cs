﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChronosApi.Models.Enderecos
{
    public class CorporacaoEnderecoModel
    {
        [Key]
        public int idCorporacaoEndereco { get; set; }

        [ForeignKey("idLogradouro")]
        public int idLogradouro { get; set; }

        [ForeignKey("idCorporacao")]
        public int idCorporacao { get; set; }
        public string numeroCorporacaoEndereco { get; set; } = string.Empty;
        public string complementoCorporacaoEndereco { get; set; } = string.Empty;

        // revisar relacionamento, a corporação não pode aceitar um Logradouro que já pertence a alguem
        // revisar no egresso também 
        [NotMapped]
        [JsonIgnore]
        public CorporacaoModel? Corporacao { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LogradouroModel? Logradouro { get; set; }
    }
}
