namespace Domain.Entities
{
    public class RickDimension : BaseEntity
    {
        public int RickId { get; set; }

        public Rick Rick { get; set; }

        public int DimensionId { get; set; }

        public Dimension Dimension { get; set; }
    }
}
