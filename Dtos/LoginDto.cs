using System.ComponentModel.DataAnnotations;

namespace ChronosApi.Dtos
{
    public record LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
