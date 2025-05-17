using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[ApiConventionType(typeof(DefaultApiConventions))]
[Produces(MediaTypeNames.Application.Json)]
public class ReportsController : ControllerBase
{
	private readonly IInfoDengueService _infoDengueService;
	private readonly IReportService _reportService;
	private readonly IRequesterService _requesterService;

	public ReportsController(IInfoDengueService infoDengueService, IReportService reportService, IRequesterService requesterService)
	{
		_infoDengueService = infoDengueService;
		_reportService = reportService;
		_requesterService = requesterService;
	}

	[HttpGet("GetAllReports")]
	public async Task<ActionResult<IEnumerable<RequesterDto>>> GetAllReports()
	{
		try
		{
			var result = await _reportService.GetAllReports();

			if (result == null)
				return NotFound("Relatórios não encontrados");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}	

	[HttpGet("GetAllReportsByGeocodeRJSP")]
	public async Task<ActionResult> GetAllReportsByGeocode(string name = "Micka xxx", string cpf = "56756756700")
	{
		try
		{
			var result = await _infoDengueService.GetDataInfoDengueByGeocodeRJSP(name, cpf, "", 1, 53, DateTime.Now.Year, DateTime.Now.Year);

			if (result == null)
				return NotFound("A consulta não retornou nenhuma informação");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	[HttpGet("GetAllReportsByIbgeCode")]
	public async Task<ActionResult> GetAllReportsByIbgeCode(string name = "Micka xxx", string cpf = "56756756700", int ibgeCode = 33, int geocode = 3304557)
	{
		try
		{
			var result = await _infoDengueService.GetDataInfoDengue(name, cpf, "", 1, 53, DateTime.Now.Year, DateTime.Now.Year, ibgeCode, geocode);

			if (result == null)
				return NotFound("A consulta não retornou nenhuma informação");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	[HttpGet("GetTotalReportsByGeocodeRJSP")]
	public async Task<ActionResult<int>> GetTotalReportsByGeocode(string name = "Micka xxx", string cpf = "56756756700")
	{
		try
		{
			var result = await _infoDengueService.GetDataInfoDengueByGeocodeRJSP(name, cpf, "", 1, 53, DateTime.Now.Year, DateTime.Now.Year);

			if (result == null)
				return NotFound("A consulta não retornou nenhuma informação");

			return Ok(result.Count());
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	[HttpGet("GetTotalReportsByDisease")]
	public async Task<ActionResult> GetTotalReportsByDisease(string name = "Micka xxx", string cpf = "56756756700", string disease = "dengue")
	{
		try
		{
			var result = await _infoDengueService.GetDataInfoDengue(name, cpf, disease, 1, 53, DateTime.Now.Year, DateTime.Now.Year, 0, 0);

			if (result == null)
				return NotFound("A consulta não retornou nenhuma informação");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	[HttpGet("GetAllReportsByFilter")]
	public async Task<ActionResult<IEnumerable<InfoDengueDto>>> GetAllReportsByFilter(string name = "Micka xxx", string cpf = "56756756700", string disease = "dengue", int startWeek = 1, int endWeek = 53, int ibgeCode = 33, int geocode = 3304557)
	{
		try
		{
			var result = await _infoDengueService.GetDataInfoDengue(name, cpf, disease, startWeek, endWeek, DateTime.Now.Year, DateTime.Now.Year, ibgeCode, geocode);

			if (result == null)
				return NotFound("A consulta não retornou nenhuma informação");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}
}
