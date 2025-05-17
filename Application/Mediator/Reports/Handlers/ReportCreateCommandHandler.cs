using Application.Mediator.Reports.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Mediator.Reports.Handlers;

public class ReportCreateCommandHandler : IRequestHandler<ReportCreateCommand, Report>
{
	private readonly IReportRepository _reportRepository;

	public ReportCreateCommandHandler(IReportRepository reportRepository)
	{
		_reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
	}

	public async Task<Report> Handle(ReportCreateCommand request, CancellationToken cancellationToken)
	{
		var entity = new Report(request.RequestDate, request.Disease, request.StartWeek, request.EndWeek, request.StartYear, request.EndYear, request.IbgeCode, request.Geocode);

		if (entity == null)
			throw new ApplicationException("Erro ao criar entidade");
		else
		{
			entity.RequesterId = request.RequesterId;
			return await _reportRepository.CreateReportAsync(entity);
		}
	}
}
