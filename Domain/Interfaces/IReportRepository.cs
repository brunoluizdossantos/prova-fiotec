using Domain.Entities;

namespace Domain.Interfaces;

public interface IReportRepository
{
	Task<IEnumerable<Report>> GetAllReportsAsync();
	Task<Report> GetReportByIdAsync(int id);
	Task<Report> CreateReportAsync(Report entity);
}
