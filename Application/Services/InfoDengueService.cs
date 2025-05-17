using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Integration;

namespace Application.Services;

public class InfoDengueService : IInfoDengueService
{
	private readonly IInfoDengueIntegrationService _infoDengueIntegrationService;

	public InfoDengueService(IInfoDengueIntegrationService infoDengueIntegrationService)
	{
		_infoDengueIntegrationService = infoDengueIntegrationService;
	}

	public async Task<IEnumerable<InfoDengueDto>> GetDataInfoDengue(int geocode, string disease, int ewStart, int ewEnd, int eyStart, int eyEnd)
	{
		var response = await _infoDengueIntegrationService.GetDataInfoDengue(geocode, disease, ewStart, ewEnd, eyStart, eyEnd);

		if (response != null && response.IsSuccessStatusCode)
			return response.Content;

		return null;
	}
}
