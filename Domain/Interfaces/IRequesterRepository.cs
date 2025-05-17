using Domain.Entities;

namespace Domain.Interfaces;

public interface IRequesterRepository
{
	Task<IEnumerable<Requester>> GetAllRequestersAsync();
	Task<Requester> GetRequesterByCpfAsync(string cpf);
	Task<Requester> CreateRequesterAsync(Requester entity);
}
