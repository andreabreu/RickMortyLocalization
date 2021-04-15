namespace RickLocalizationAPI.Models
{
    public class MortyModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        public RickModel Rick { get; set; }

        public DimensionModel Dimension { get; set; }

    }
}
