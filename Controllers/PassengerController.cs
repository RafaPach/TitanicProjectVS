using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using Microsoft.AspNetCore.Mvc;



namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("passengers")]
    public class DeveloperPathwaysController : ControllerBase
    {
        private readonly TitanicContext _context;
        public DeveloperPathwaysController(TitanicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PassengerDto>> GetPassengers([FromQuery] bool? survived)
        {
            var passengers = _context.Passengers.AsQueryable();

            if (survived.HasValue)
            {
                passengers = passengers.Where(p => p.Survived == survived.Value);
            }

            var passengerDto = passengers.Select(x => x.ToPassengerDto()).ToList();

            return Ok(passengerDto);
        }



       [HttpGet("{id:int}")]
        public ActionResult<PassengerDto> GetPassengerById([FromRoute] int id)
        {
            var passenger = _context.Passengers.FirstOrDefault(p => p.PassengerId == id);
            
            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger.ToPassengerDto());
        }

    }
    
}