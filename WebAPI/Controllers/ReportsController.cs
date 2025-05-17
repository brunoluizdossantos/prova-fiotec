using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[ApiConventionType(typeof(DefaultApiConventions))]
[Produces(MediaTypeNames.Application.Json)]
public class ReportsController : ControllerBase
{
	private readonly IReportService _reportService;
	private readonly IRequesterService _requesterService;

	public ReportsController(IReportService reportService, IRequesterService requesterService)
	{
		_reportService = reportService;
		_requesterService = requesterService;
	}

	[HttpPost("CreateReport")]
	public async Task<ActionResult<ReportDto>> Post([FromBody] ReportDto reportDto)
	{
		try
		{
			if (reportDto == null)
				return BadRequest("Dados inválidos");

			var requesterDto = new RequesterDto()
			{
				Name = reportDto.Name,
				Cpf = reportDto.Cpf
			};

			var requester = await this.GetRequester(requesterDto);

			if (requesterDto == null)
				return BadRequest("Erro ao tentar cadastrar relatório");
			else
				reportDto.RequesterId = requester.RequesterId;

			var newReporter = await _reportService.CreateReport(reportDto);

			return Ok(newReporter);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar cadastrar relatório");
		}
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
	
	// Listar todos os dados epidemiológicos do município do Rio de Janeiro e São Paulo
	[HttpGet("GetAllReportsByGeocodeRJSP")]
	public async Task<ActionResult> GetAllReportsByGeocode()
	{
		try
		{
			return Ok();
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	// Listar os dados epidemiológicos dos municípios pelo código IBGE
	[HttpGet("GetAllReportsByIbgeCode")]
	public async Task<ActionResult> GetAllReportsByIbgeCode()
	{
		try
		{
			return Ok();
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	// Listar o total de casos epidemiológicos dos municípios do Rio de Janeiro e São Paulo
	[HttpGet("GetTotalReportsByGeocodeRJSP")]
	public async Task<ActionResult> GetTotalReportsByGeocode()
	{
		try
		{
			return Ok();
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os relatórios");
		}
	}

	// Listar o total de casos epidemiológicos dos municípios por arbovirose
	[HttpGet("GetTotalReportsByDisease")]
	public async Task<ActionResult> GetTotalReportsByDisease()
	{
		return Ok();
	}

	// Listar os dados epidemiológicos dos municípios pelo código IBGE, semana início, semana fim e arbovirose
	[HttpGet("GetAllReportsByFilter")]
	public async Task<ActionResult> GetAllReportsByFilter()
	{
		return Ok();
	}

	private async Task<RequesterDto> GetRequester(RequesterDto requesterDto)
	{
		var requesterExists = await _requesterService.GetRequesterByCpf(requesterDto.Cpf);

		if (requesterExists != null)
			return requesterExists;

		var newRequester = await _requesterService.CreateRequester(requesterDto);

		return newRequester;
	}
}
