using System.Collections.Generic;

namespace Domain.Entities
{
    public class Dimension : BaseEntity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public List<RickDimension> RickDimensions { get; set; }

    }
}
