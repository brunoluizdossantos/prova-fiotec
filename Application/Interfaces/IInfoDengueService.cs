using Application.DTOs;

namespace Application.Interfaces;

public interface IInfoDengueService
{
	Task<IEnumerable<InfoDengueDto>> GetDataInfoDengue(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode);
	Task<IEnumerable<InfoDengueDto>> GetDataInfoDengueByGeocodeRJSP(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear);
}
