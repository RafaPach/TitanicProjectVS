using DeveloperPathways.Models;

namespace DeveloperPathways.Dtos
{
    public class SurvivalDto
    {
        public GenderStats Survived { get; set; } = new GenderStats();
        public GenderStats Perished { get; set; } = new GenderStats();
    }
}