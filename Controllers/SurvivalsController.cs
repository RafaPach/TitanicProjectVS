using DeveloperPathways.Application.Queries;
using DeveloperPathways.Data;
using DeveloperPathways.Mappers;
using DeveloperPathways.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("survival")]
    public class SurvivalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SurvivalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<FinalSurvivalRate>> GetSurvivalRates()

        {
            var result = await _mediator.Send(new GetSurvivalsQuery());

            return Ok(result);
        }
    }
}