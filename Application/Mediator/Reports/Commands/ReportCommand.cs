using Domain.Entities;
using MediatR;

namespace Application.Mediator.Reports.Commands;

public class ReportCommand : IRequest<Report>
{
	public DateTime RequestDate { get; set; }
	public string Disease { get; set; } = string.Empty;
	public int StartWeek { get; set; }
	public int EndWeek { get; set; }
	public int StartYear { get; set; }
	public int EndYear { get; set; }
	public string IbgeCode { get; set; } = string.Empty;
	public string Geocode { get; set; } = string.Empty;
	public int RequesterId { get; set; }
}
