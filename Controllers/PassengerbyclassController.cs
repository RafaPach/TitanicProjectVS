using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using MediatR;
using DeveloperPathways.Application.Queries;

namespace DeveloperPathways.Controllers
{
    [ApiController]
    [Route("passenger-class")] 
    public class PassengerByClassController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PassengerByClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<FinalClassBreakDown>> GetByClass()
        {

            var result = await _mediator.Send(new GetByClassQuery());

            return Ok(result);
        }
    }
}