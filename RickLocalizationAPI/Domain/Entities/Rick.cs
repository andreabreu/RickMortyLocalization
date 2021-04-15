using System.Collections.Generic;

namespace Domain.Entities
{
    public class Rick : BiographicalInformation
    {
        public string Species { get; set; }

        public Morty Morty { get; set; }

        public int DimensionId { get; set; }

        public Dimension Dimension { get; set; }

        public List<RickDimension> RickDimensions { get; set; }
    }
}
