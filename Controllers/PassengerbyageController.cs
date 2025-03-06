using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("passenger-by-age")] 
    public class PassengerByAgeController : ControllerBase
    {
        private readonly TitanicContext _context;

        public PassengerByAgeController(TitanicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PassengerDto>> GetByAge()
        {
            var passengers = _context.Passengers
                .Where(p => p.Age.HasValue) 
                .OrderBy(p => p.Age) 
                .Select(d => d.ToPassengerDto())
                .ToList();

            return Ok(passengers);
        }
    }
}