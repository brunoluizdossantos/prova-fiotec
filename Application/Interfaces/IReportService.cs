using Application.DTOs;

namespace Application.Interfaces;

public interface IReportService
{
	Task<IEnumerable<ReportDto>> GetAllReports();
	Task<ReportDto> GetReportById(int id);
	Task<ReportDto> CreateReport(ReportDto dto);
}
