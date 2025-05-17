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
	public int IbgeCode { get; set; }
	public int Geocode { get; set; }
	public int RequesterId { get; set; }
}
