namespace Api_Development.Models.Domain
{
    public class Caminhada
    {
        public Guid CaminhadaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public double DistanciaKm { get; set; }

        public string? CaminhadaImagemUrl { get; set; }

        public Guid DificuldadeId { get; set; }

        public Guid RegiaoId { get; set; }

        //Navigation Properties
        public Dificuldade Dificuldade { get; set; }
        public Regiao Regiao { get; set; }
    }
}
