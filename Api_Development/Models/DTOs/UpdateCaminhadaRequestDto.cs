using System.ComponentModel.DataAnnotations;

namespace Api_Development.Models.DTOs
{
    public class UpdateCaminhadaRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage ="O campo Nome deve ter no máximo 100 carateres.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "O campo Descrição deve ter no máximo 1000 carateres.")]
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
