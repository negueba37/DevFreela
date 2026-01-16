using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
	public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
	{
		private readonly IProjectRepository _repository;
        public FinishProjectCommandHandler(IProjectRepository repository)
        {
			_repository = repository;
        }
        async Task<Unit> IRequestHandler<FinishProjectCommand, Unit>.Handle(FinishProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _repository.GetByIdAsync(request.Id);
			project.Finish();
			_repository.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
