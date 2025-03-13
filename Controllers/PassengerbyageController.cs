using DeveloperPathways.Application.Queries.GetByAge;
using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("passenger-by-age")] 
    public class PassengerByAgeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PassengerByAgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
          public async Task<ActionResult<List<PassengerDto>>> GetByAge()
        {
            var passengers = await _mediator.Send(new GetPassengersByAgeQuery());
            return Ok(passengers);
        }
    }
}