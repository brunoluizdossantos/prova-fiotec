using Application.DTOs;

namespace Application.Interfaces;

public interface IRequesterService
{
	Task<IEnumerable<RequesterDto>> GetAllRequesters();
	Task<RequesterDto> GetRequesterByCpf(string cpf);
	Task<RequesterDto> CreateRequester(RequesterDto dto);
}
