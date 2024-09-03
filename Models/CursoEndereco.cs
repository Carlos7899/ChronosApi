namespace ChronosApi.Models
{
    public class CursoEndereco
    {

        public int idCursoEndereco { get; set; }
        public int idLogradouro { get; set; } // FK 
        public string numeroCursoEndereco { get; set; } = string.Empty; 
        public string complementoCursoEndereco { get; set; } = string.Empty;

    }
}
