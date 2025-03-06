using DeveloperPathways.Data;
using DeveloperPathways.Mappers;
using DeveloperPathways.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("survival")]
    public class SurvivalController : ControllerBase
    {
        private readonly TitanicContext _context;

        public SurvivalController(TitanicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<FinalSurvivalRate> GetSurvivals()
        {
            var totalMales = _context.Passengers.Count(p => p.Sex == "male");
            var totalFemales = _context.Passengers.Count(p => p.Sex == "female");

            var result = _context.Passengers
                .AsEnumerable() // Added for testing. AsEnumerable converts to an in-memory collection without materializing the entire list.
                .GroupBy(p => new { p.Survived, p.Sex })
                .ToList();

            var final = result.ToSurvivalStatsDto(totalMales, totalFemales);

            return Ok(new FinalSurvivalRate { SurvivalRates = final });
        }
    }
}