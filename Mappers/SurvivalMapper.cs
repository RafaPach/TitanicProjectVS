using System.Collections.Generic;
using DeveloperPathways.Domain;
using DeveloperPathways.Dtos;
using DeveloperPathways.Models;

namespace DeveloperPathways.Mappers
{
    public static class SurvivalMapper
    {
        public static SurvivalDto ToSurvivalStatsDto(
            this IEnumerable<IGrouping<dynamic, Passenger>> groups,
            int totalMales,
            int totalFemales)
        {
            var survivalStats = new SurvivalDto
            {
                Survived = new GenderStats(),
                Perished = new GenderStats()
            };

            foreach (var group in groups)
            {
                var survived = group.Key.Survived;
                var gender = group.Key.Sex;
                var count = group.Count();

                if (survived)
                {
                    if (gender == "male")
                        survivalStats.Survived.Male = CalculatePercentage(count, totalMales);
                    else
                        survivalStats.Survived.Female = CalculatePercentage(count, totalFemales);
                }
                else
                {
                    if (gender == "male")
                        survivalStats.Perished.Male = CalculatePercentage(count, totalMales);
                    else
                        survivalStats.Perished.Female = CalculatePercentage(count, totalFemales);
                }
            }

            return survivalStats;
        }

        private static double CalculatePercentage(int count, int total)
        {
            return total == 0 ? 0 : (double)count / total * 100;
        }
    }
}