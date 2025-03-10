using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperPathways.Dtos;
using DeveloperPathways.Domain; 


namespace DeveloperPathways.Mappers
{
    public static class PassengerMapper
    {
        public static PassengerDto ToPassengerDto(this Passenger passenger)
        {
                return new PassengerDto
            {
                Id = passenger.PassengerId,
                Name = passenger.Name,
                Sex = passenger.Sex,
                Age = passenger.Age.HasValue ? Math.Round(passenger.Age.Value, MidpointRounding.AwayFromZero) : (double?)null,
                Fare = passenger.Fare,
                Cabin = passenger.Cabin
            };
        }

        public static Passenger ToPassenger(this PassengerDto passengerDto)
        {
            return new Passenger(passengerDto.Name, null, null); // Default Pclass and Survived to null
        }
    }
}



//        public static Passenger ToPassenger(this PassengerDto passengerDto)
//        {
//            return new Passenger(passengerDto.Name, passengerDto.Pclass, null) // Adjust constructor call
//            {
//                PassengerId = passengerDto.Id,
//                Sex = passengerDto.Sex,
//                Age = passengerDto.Age,
//                Fare = passengerDto.Fare,
//                Cabin = passengerDto.Cabin
//            };
//        }
//    }

