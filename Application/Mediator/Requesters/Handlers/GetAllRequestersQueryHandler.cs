using Application.Mediator.Requesters.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Requesters.Handlers;

public class GetAllRequestersQueryHandler : IRequestHandler<GetAllRequestersQuery, IEnumerable<Requester>>
{
	private readonly IRequesterRepository _requesterRepository;

	public GetAllRequestersQueryHandler(IRequesterRepository requesterRepository)
	{
		_requesterRepository = requesterRepository ?? throw new ArgumentNullException(nameof(requesterRepository));
	}

	public async Task<IEnumerable<Requester>> Handle(GetAllRequestersQuery request, CancellationToken cancellationToken)
	{
		return await _requesterRepository.GetAllRequestersAsync();
	}
}
