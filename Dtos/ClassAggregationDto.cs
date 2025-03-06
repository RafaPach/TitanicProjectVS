namespace DeveloperPathways.Dtos
{   public class ClassAggregdationDto
    {
        public List<PassengerDto> FirstClass { get; set; } = [];
        public List<PassengerDto> SecondClass { get; set; } = [];
        public List<PassengerDto> ThirdClass { get; set; } = [];
    }
}