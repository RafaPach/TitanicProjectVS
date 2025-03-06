using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperPathways.Dtos;
//using DeveloperPathways.Models;
using DeveloperPathways.Domain;

namespace DeveloperPathways.Mappers
{
    public static class PassengerMapper
    {
        public static PassengerDto ToPassengerDto(this Passenger passengerModel)
        {
            return new PassengerDto
            {

                Id = passengerModel.PassengerId,
                Name = passengerModel.Name,
                Sex = passengerModel.Sex,
                Age = passengerModel.Age.HasValue ? Math.Round(passengerModel.Age.Value, MidpointRounding.AwayFromZero) : (double?)null,
                Fare = passengerModel.Fare,
                Cabin = passengerModel.Cabin,
                Pclass = passengerModel.Pclass,
                Survived = passengerModel.Survived
            };
        }

        public static Passenger ToPassenger(this PassengerDto passengerDto)
        {
            return new Passenger(passengerDto.Name, passengerDto.Pclass, passengerDto.Survived);
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
}
