using Application.DTOs;
using Application.Interfaces;
using Application.Mediator.Reports.Commands;
using Application.Mediator.Reports.Queries;
using AutoMapper;
using MediatR;

namespace Application.Services;

public class ReportService : IReportService
{
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public ReportService(IMapper mapper, IMediator mediator)
	{
		_mapper = mapper;
		_mediator = mediator;
	}

	public async Task<IEnumerable<ReportDto>> GetAllReports()
	{
		var query = new GetAllReportsQuery() ?? throw new NullReferenceException("Não foi possível carregar a entidade");
		var result = await _mediator.Send(query);
		return _mapper.Map<IEnumerable<ReportDto>>(result);
	}

	public async Task<ReportDto> GetReportById(int id)
	{
		var query = new GetReportByIdQuery(id) ?? throw new NullReferenceException("Não foi possível carregar a entidade");
		var result = await _mediator.Send(query);
		return _mapper.Map<ReportDto>(result);
	}

	public async Task<ReportDto> CreateReport(ReportDto dto)
	{
		dto.RequestDate = DateTime.Now;
		var query = _mapper.Map<ReportCreateCommand>(dto);
		var result = await _mediator.Send(query);
		return dto;
	}
}
