using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetByIdUser;
using DevFreelaApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaApi.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		
		private readonly IMediator _mediator;	
		public UsersController( IMediator mediator)
        {		
			_mediator = mediator;
        }
        [HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetByIdUserQuery(id);		
			return Ok(await _mediator.Send(query));
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
		{
			var idUser = await _mediator.Send(command);
			
			return CreatedAtAction(nameof(GetById), new { id = idUser}, command);
		}
		[HttpPut("{id}/login")]
		public IActionResult Login(int id, [FromBody] LoginModel loginModel)
		{
			return NoContent();
		}
	}
}
