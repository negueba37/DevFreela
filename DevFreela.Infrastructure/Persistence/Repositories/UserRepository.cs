using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		public UserDTO GetById(int id)
		{
			var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
			return new UserDTO(user.FullName, user.Email);
		}
		public int CreateAsync(User user)
		{		
			_dbContext.Users.AddAsync(user);
			_dbContext.SaveChangesAsync();
			return user.Id;
		}

	}
}
