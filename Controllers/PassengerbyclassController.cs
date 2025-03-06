using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;

namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("passenger-class")] 
    public class PassengerByClassController : ControllerBase
    {
        private readonly TitanicContext _context;

        public PassengerByClassController(TitanicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<FinalClassBreakDown>> GetByClass()
        {
        
        var passengerByClass = _context.Passengers.ToList().ToClassAggregdationDto();

        var final = new FinalClassBreakDown {
            ClassBreakdown = passengerByClass
        };

        return Ok(final);

        }
    }
}