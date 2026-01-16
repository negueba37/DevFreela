using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaApi.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : Controller
	{
		
		private readonly IMediator _mediator;
		public ProjectsController(IMediator mediator)
		{			
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll(string query)
		{
			var getAllProjectQuery = new GetAllProjectsQuery(query);
			var projects = await _mediator.Send(getAllProjectQuery);
			return Ok(projects);
		}
		[HttpGet("{id}")]
		public IActionResult GetbyId(int id) 
		{ 
			
			
			return Ok();
		}
		[HttpPost]
		public IActionResult Post([FromBody] CreateProjectCommand command)
		{
			if (command.Title.Length > 50)
			{
				return BadRequest();
			}
			var idProject = _mediator.Send(command);
			return CreatedAtAction(nameof(GetbyId), new { id = idProject }, command);
		}
		[HttpPost("{id}/comments")]
		public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command) 
		{
			await _mediator.Send(command);		
			return NoContent();
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
		{
			if (command.Description.Length > 200)
			{
				return BadRequest();
			}
			await _mediator.Send(command);			
			return NoContent();
		}
		[HttpPut("{id}/start")]
		public async Task<IActionResult> Start(int id) 
		{
			var startProject = new StartProjectCommand(id);
			await _mediator.Send(startProject);			
			return NoContent();
		}
		[HttpPut("{id}/finish")]
		public async Task<IActionResult> Finish(int id)
		{
			var finishProject = new FinishProjectCommand(id);
			await _mediator.Send(finishProject);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{			
			return NoContent();
		}
	}
}
