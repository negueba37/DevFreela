using DevFreela.Application.ViewModels;
using DevFreela.Core.DTO;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdUser
{
	public class GetByIdUserQuery: IRequest<UserDTO>
	{
		public GetByIdUserQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
