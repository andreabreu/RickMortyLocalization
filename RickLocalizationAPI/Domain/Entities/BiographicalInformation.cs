namespace Domain.Entities
{
    public class BiographicalInformation : BaseEntity
    {
        public string Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }
    }
}
