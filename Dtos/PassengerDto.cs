namespace DeveloperPathways.Dtos
{
    public class PassengerDto
    {
     
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public double? Age { get; set; }
        public double? Fare { get; set; }
        public string? Cabin { get; set; }
        public int? Pclass { get; set; }
        public bool? Survived { get; set; }
    }
}
