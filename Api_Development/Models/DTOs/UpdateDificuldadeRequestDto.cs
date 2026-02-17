using Api_Development.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Api_Development.Models.DTOs
{
    public class UpdateDificuldadeRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage ="O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
