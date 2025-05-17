using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class ReportRepository : IReportRepository
{
	readonly ApplicationDbContext _context;

	public ReportRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Report>> GetAllReportsAsync()
	{
		IQueryable<Report> query = (
			from c in _context.Report.AsNoTracking()
			select c);

		return await query.OrderByDescending(p => p.ReportId).ToListAsync();
	}

	public async Task<Report> GetReportByIdAsync(int id)
	{
		IQueryable<Report> query = (
			from c in _context.Report.AsNoTracking()
			where c.ReportId == id
			select c);

		return await query.OrderBy(p => p.ReportId).FirstOrDefaultAsync();
	}

	public async Task<Report> CreateReportAsync(Report entity)
	{
		_context.Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}
}
