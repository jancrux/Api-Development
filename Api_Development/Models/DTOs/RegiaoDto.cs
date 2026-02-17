namespace Api_Development.Models.DTOs
{
    public class RegiaoDto
    {

        public Guid RegiaoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string? ImagemRegiaoUrl { get; set; }
    }
}
