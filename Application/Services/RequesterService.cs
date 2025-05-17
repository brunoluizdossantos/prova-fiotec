using Application.DTOs;
using Application.Interfaces;
using Application.Mediator.Requesters.Commands;
using Application.Mediator.Requesters.Queries;
using AutoMapper;
using MediatR;

namespace Application.Services;

public class RequesterService : IRequesterService
{
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public RequesterService(IMapper mapper, IMediator mediator)
	{
		_mapper = mapper;
		_mediator = mediator;
	}

	public async Task<IEnumerable<RequesterDto>> GetAllRequesters()
	{
		var query = new GetAllRequestersQuery() ?? throw new NullReferenceException("Não foi possível carregar a entidade");
		var result = await _mediator.Send(query);
		return _mapper.Map<IEnumerable<RequesterDto>>(result);
	}

	public async Task<RequesterDto> GetRequesterByCpf(string cpf)
	{
		var query = new GetRequesterByCpfQuery(cpf) ?? throw new NullReferenceException("Não foi possível carregar a entidade");
		var result = await _mediator.Send(query);
		return _mapper.Map<RequesterDto>(result);
	}

	public async Task<RequesterDto> CreateRequester(RequesterDto dto)
	{
		var query = _mapper.Map<RequesterCreateCommand>(dto);
		var result = await _mediator.Send(query);
		dto.RequesterId = result.RequesterId;
		return dto;
	}
}
