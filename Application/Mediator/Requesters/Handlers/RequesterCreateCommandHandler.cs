using Application.Mediator.Requesters.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Requesters.Handlers;

public class RequesterCreateCommandHandler : IRequestHandler<RequesterCreateCommand, Requester>
{
	private readonly IRequesterRepository _requesterRepository;

	public RequesterCreateCommandHandler(IRequesterRepository requesterRepository)
	{
		_requesterRepository = requesterRepository ?? throw new ArgumentNullException(nameof(requesterRepository));
	}

	public async Task<Requester> Handle(RequesterCreateCommand request, CancellationToken cancellationToken)
	{
		var entity = new Requester(request.Name, request.Cpf);

		if (entity == null)
			throw new ApplicationException("Erro ao criar entidade");
		else
			return await _requesterRepository.CreateRequesterAsync(entity);
	}
}
