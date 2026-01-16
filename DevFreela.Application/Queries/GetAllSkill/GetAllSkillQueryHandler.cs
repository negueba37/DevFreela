using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkill
{
	public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillDTO>>
	{
		private readonly ISkillRepository _skillRepository;
        public GetAllSkillQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<List<SkillDTO>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
		{
			return _skillRepository.GetAll();	
		}
	}
}
