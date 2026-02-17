namespace Api_Development.Models.Domain
{
    public class Regiao
    {
        public Guid RegiaoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string? ImagemRegiaoUrl { get; set; }
    }
}
