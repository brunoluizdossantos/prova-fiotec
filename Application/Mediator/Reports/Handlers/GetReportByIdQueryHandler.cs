using Application.Mediator.Reports.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Reports.Handlers;

public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, Report>
{
	private readonly IReportRepository _reportRepository;

	public GetReportByIdQueryHandler(IReportRepository reportRepository)
	{
		_reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
	}

	public async Task<Report> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
	{
		return await _reportRepository.GetReportByIdAsync(request.Id);
	}
}