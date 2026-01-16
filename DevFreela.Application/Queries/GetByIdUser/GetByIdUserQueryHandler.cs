using DevFreela.Application.ViewModels;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetByIdUser
{
	public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDTO>
	{
        private readonly IUserRepository _userRepository;
		public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
		{
			return _userRepository.GetById(request.Id);
		}
	}
}
