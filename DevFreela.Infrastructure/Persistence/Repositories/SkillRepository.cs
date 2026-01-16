using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class SkillRepository : ISkillRepository
	{
		private readonly DevFreelaDbContext _dbContext;
        public SkillRepository(DevFreelaDbContext context)
        {
            _dbContext = context;
        }
        public List<SkillDTO> GetAll()
		{
			var skills = _dbContext.Skills;

			var SkillDTO = skills
				.Select(s => new SkillDTO(s.Id, s.Description))
				.AsNoTracking()
				.ToList();

			return SkillDTO;
		}
	}
}
