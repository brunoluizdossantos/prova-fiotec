using Domain.Entities;
using MediatR;

namespace Application.Mediator.Requesters.Queries;

public class GetAllRequestersQuery : IRequest<IEnumerable<Requester>>
{
	public GetAllRequestersQuery()
	{
	}
}