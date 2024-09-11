using System.ComponentModel.DataAnnotations;

namespace ChronosApi.Dtos
{
    public record UsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
