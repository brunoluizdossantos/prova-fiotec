using Application.DTOs;

namespace Application.Interfaces;

public interface IInfoDengueService
{
	Task<IEnumerable<InfoDengueDto>> GetDataInfoDengue(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear, int ibgeCode, int geocode);
	Task<IEnumerable<InfoDengueDto>> GetDataInfoDengueByGeocodeRJSP(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear);
}
