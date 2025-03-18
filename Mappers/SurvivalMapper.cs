using DeveloperPathways.Domain;
using DeveloperPathways.Dtos;
using DeveloperPathways.Models;

public static class SurvivalMapper
{
    public static SurvivalDto ToSurvivalStatsDto(
        this List<Passenger> passengers,
        int totalMales,
        int totalFemales)
    {
        var survivalStats = new SurvivalDto
        {
            Survived = new GenderStats(),
            Perished = new GenderStats()
        };

        // Calculate survival rates for males
        // For survival, check if p.Survived == true
        survivalStats.Survived.Male = CalculatePercentage(
            passengers.Count(p => p.Sex == "male" && p.Survived == true),
            totalMales
        );
        survivalStats.Perished.Male = CalculatePercentage(
            passengers.Count(p => p.Sex == "male" && p.Survived == false),
            totalMales
        );

        // For females
        survivalStats.Survived.Female = CalculatePercentage(
            passengers.Count(p => p.Sex == "female" && p.Survived == true),
            totalFemales
        );
        survivalStats.Perished.Female = CalculatePercentage(
            passengers.Count(p => p.Sex == "female" && p.Survived == false),
            totalFemales
        );


        return survivalStats;
    }

    private static double CalculatePercentage(int count, int total)
    {
        return total == 0 ? 0 : (double)count / total * 100;
    }
}