using Application.Mediator.Reports.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Reports.Handlers;

public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, IEnumerable<Report>>
{
	private readonly IReportRepository _reportRepository;

	public GetAllReportsQueryHandler(IReportRepository reportRepository)
	{
		_reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
	}

	public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
	{
		return await _reportRepository.GetAllReportsAsync();
	}
}
