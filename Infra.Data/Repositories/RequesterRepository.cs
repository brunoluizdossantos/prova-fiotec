using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class RequesterRepository : IRequesterRepository
{
	readonly ApplicationDbContext _context;

	public RequesterRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Requester>> GetAllRequestersAsync()
	{
		IQueryable<Requester> query = (
			from c in _context.Requester.AsNoTracking()
			select c);

		return await query.OrderBy(p => p.Name).ToListAsync();
	}
	
	public async Task<Requester> GetRequesterByCpfAsync(string cpf)
	{
		IQueryable<Requester> query = (
			from c in _context.Requester.AsNoTracking()
			select c);

		if (cpf.Length > 0)
			query = query.Where(p => p.Cpf.Equals(cpf));

		return await query.OrderBy(p => p.Name).FirstOrDefaultAsync();
	}

	public async Task<Requester> CreateRequesterAsync(Requester entity)
	{
		_context.Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}
}
