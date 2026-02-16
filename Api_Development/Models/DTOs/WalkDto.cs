namespace Api_Development.Models.DTOs
{
    public class WalkDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthinKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid Id_Difficulty { get; set; }

        public Guid Id_Region { get; set; }


    }
}
