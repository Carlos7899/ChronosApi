namespace ChronosApi.Models
{
    public class Candidatura
    {
        public int idCandidatura { get; set; }
        public int idEgresso { get; set; } //FK
        public int idVaga { get; set; } //FK
        public DateTime dataIncricao { get; set; } 
    }
}
