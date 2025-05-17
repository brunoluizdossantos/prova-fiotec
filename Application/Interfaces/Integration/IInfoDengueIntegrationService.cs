using Application.DTOs;
using Refit;

namespace Application.Interfaces.Integration;

public interface IInfoDengueIntegrationService
{
	[Get("/api/alertcity?geocode={geocode}&disease={disease}&format=json&ew_start={ewStart}&ew_end={ewEnd}&ey_start={eyStart}&ey_end={eyEnd}")]
	Task<ApiResponse<IEnumerable<InfoDengueDto>>> GetDataInfoDengue(int geocode, string disease, int ewStart, int ewEnd, int eyStart, int eyEnd);
}
