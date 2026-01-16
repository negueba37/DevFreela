using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
	public interface IUserRepository
	{
		public UserDTO GetById(int id);
		public int CreateAsync(User user);
	}
}
