using System.ComponentModel.DataAnnotations;

namespace Api_Development.Models.DTOs
{
    public class DificuldadeDto
    {
        [Required]

        [MaxLength(100, ErrorMessage = "O Nome deve ter nomáximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
