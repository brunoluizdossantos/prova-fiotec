using Domain.Entities;
using MediatR;

namespace Application.Mediator.Reports.Queries;

public class GetAllReportsQuery : IRequest<IEnumerable<Report>>
{
	public GetAllReportsQuery()
	{
	}
}
