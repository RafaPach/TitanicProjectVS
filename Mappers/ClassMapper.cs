using System.Collections.Generic;
using System.Linq;
using DeveloperPathways.Domain;
using DeveloperPathways.Dtos;
using DeveloperPathways.Models;

namespace DeveloperPathways.Mappers
{
    public static class ClassMapper
{
    public static ClassAggregdationDto ToClassAggregdationDto(this IEnumerable<Passenger> passengers)
    {
        var classDto = new ClassAggregdationDto();

            var groupedPassengers = passengers
            .Where(p => p.Pclass.HasValue) 
            .GroupBy(p => p.Pclass!.Value)  
            .ToDictionary(
                g => g.Key, 
                g => g.Select(p => p.ToPassengerDto()).ToList()
            ); //  https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.trygetvalue?view=net-9.0 

        if (groupedPassengers.TryGetValue(1, out var firstClassPassengers))
            classDto.FirstClass = firstClassPassengers;

        if (groupedPassengers.TryGetValue(2, out var secondClassPassengers))
            classDto.SecondClass = secondClassPassengers;

        if (groupedPassengers.TryGetValue(3, out var thirdClassPassengers))
            classDto.ThirdClass = thirdClassPassengers;

        return classDto;
    }
}
}