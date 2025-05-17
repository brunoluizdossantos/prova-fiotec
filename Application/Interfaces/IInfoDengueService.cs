using Application.DTOs;

namespace Application.Interfaces;

public interface IInfoDengueService
{
	Task<IEnumerable<InfoDengueDto>> GetDataInfoDengue(int geocode, string disease, int ewStart, int ewEnd, int eyStart, int eyEnd);
}
