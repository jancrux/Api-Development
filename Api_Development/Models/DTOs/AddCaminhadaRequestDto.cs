using Api_Development.Models.Domain;

namespace Api_Development.Models.DTOs
{
    public class AddCaminhadaRequestDto
    {


        public string Nome { get; set; }
        public string Descricao { get; set; }

        public double DistanciaKm { get; set; }

        public string? CaminhadaImagemUrl { get; set; }

        public Guid DificuldadeId { get; set; }

        public Guid RegiaoId { get; set; }

    }
}
