using Application.Mediator.Requesters.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Requesters.Handlers;

public class GetRequesterByCpfQueryHandler : IRequestHandler<GetRequesterByCpfQuery, Requester>
{
	private readonly IRequesterRepository _requesterRepository;

	public GetRequesterByCpfQueryHandler(IRequesterRepository requesterRepository)
	{
		_requesterRepository = requesterRepository ?? throw new ArgumentNullException(nameof(requesterRepository));
	}

	public async Task<Requester> Handle(GetRequesterByCpfQuery request, CancellationToken cancellationToken)
	{
		return await _requesterRepository.GetRequesterByCpfAsync(request.Cpf);
	}
}
