using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProject
{
	public class GetAllProjectsQuery: IRequest<List<ProjectViewModel>>
	{
		public GetAllProjectsQuery(string query)
		{
			Query = query;
		}

		public string Query { get; set; }
    }
}
