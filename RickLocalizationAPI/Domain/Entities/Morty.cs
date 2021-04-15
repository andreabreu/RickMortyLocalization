namespace Domain.Entities
{
    public class Morty : BiographicalInformation
    {
        public int RickId { get; set; }

        public Rick Rick { get; set; }

        public int DimensionId { get; set; }

        public Dimension Dimension { get; set; }
    }
}
