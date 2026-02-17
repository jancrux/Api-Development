using System.ComponentModel.DataAnnotations;

namespace Api_Development.Models.DTOs
{
    public class UpdateRegiaoRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "O campo Código deve ter no minimo 3 caracteres.")]
        [MaxLength(3, ErrorMessage = "O campo Código deve ter no máximo 3 caracteres.")]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        public string? ImagemRegiaoUrl { get; set; }
    }
}
