using Application.DTOs;
using Refit;

namespace Application.Interfaces.Integration;

public interface IInfoDengueIntegrationService
{
	[Get("/api/alertcity?geocode={geocode}&disease={disease}&format=json&ew_start={startWeek}&ew_end={endWeek}&ey_start={startYear}&ey_end={endYear}")]
	Task<ApiResponse<IEnumerable<InfoDengueDto>>> GetDataInfoDengue(int geocode, string disease, int startWeek, int endWeek, int startYear, int endYear);
}
