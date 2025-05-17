using Domain.Entities;
using MediatR;

namespace Application.Mediator.Requesters.Queries;

public class GetRequesterByCpfQuery : IRequest<Requester>
{
	public string Cpf { get; set; }

	public GetRequesterByCpfQuery(string cpf)
	{
		Cpf = cpf;
	}
}
