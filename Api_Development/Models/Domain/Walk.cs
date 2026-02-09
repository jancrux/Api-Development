namespace Api_Development.Models.Domain
{
    public class Walk
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthinKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid Id_Difficulty { get; set; }

        public Guid Id_Region { get; set; }

        //Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
