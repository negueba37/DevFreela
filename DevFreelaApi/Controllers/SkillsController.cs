using DevFreela.Application.Queries.GetAllSkill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
	[Route("api/[controller]")]
	public class SkillsController : Controller
	{
		private readonly IMediator _mediator;

		public SkillsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var query = new GetAllSkillQuery();
			return Ok(await _mediator.Send(query));
		}
	}
}
