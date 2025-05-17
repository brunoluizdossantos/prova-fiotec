using Domain.Entities;
using MediatR;

namespace Application.Mediator.Requesters.Commands;

public class RequesterCommand : IRequest<Requester>
{
	public string Name { get; set; } = string.Empty;
	public string Cpf { get; set; } = string.Empty;
}
