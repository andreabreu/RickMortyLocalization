using Domain.Models;
using System.Collections.Generic;

namespace RickLocalizationAPI.Models
{
    public class RickModel
    {
        public int Id { get; set; }

        public string Species { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        public MortyModel Morty { get; set; }

        public DimensionModel Dimension { get; set; }

        public List<RickDimensionModel> RickDimensions { get; set; }

    }
}
