using Domain.Entities;
using MediatR;

namespace Application.Mediator.Reports.Queries;

public class GetReportByIdQuery : IRequest<Report>
{
	public int Id { get; set; }

	public GetReportByIdQuery(int id)
	{
		Id = id;
	}
}
