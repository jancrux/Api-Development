using System.ComponentModel.DataAnnotations;

namespace Api_Development.Models.DTOs
{
    public class CaminhadaDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [Range(0,50)]
        public double DistanciaKm { get; set; }

        public string? CaminhadaImagemUrl { get; set; }

        [Required]
        public Guid DificuldadeId { get; set; }

        [Required]
        public Guid RegiaoId { get; set; }
    }
}
