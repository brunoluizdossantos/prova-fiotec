using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestersController : ControllerBase
{
	private readonly IRequesterService _requesterService;

	public RequestersController(IRequesterService requesterService)
	{
		_requesterService = requesterService;
	}

	[HttpPost("CreateRequester")]
	public async Task<ActionResult<RequesterDto>> Post([FromBody] RequesterDto requesterDto)
	{
		try
		{
			if (requesterDto == null)
				return BadRequest("Dados inválidos");

			var requesterExists = await _requesterService.GetRequesterByCpf(requesterDto.Cpf);

			if (requesterExists != null)
				return Ok(requesterExists);
			
			var newRequester = await _requesterService.CreateRequester(requesterDto);

			return Ok(newRequester);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar cadastrar solicitante");
		}
	}

	[HttpGet("GetAllRequesters")]
	public async Task<ActionResult<IEnumerable<RequesterDto>>> GetAllRequesters()
	{
		try
		{
			var result = await _requesterService.GetAllRequesters();

			if (result == null)
				return NotFound("Solicitantes não encontrados");

			return Ok(result);
		}
		catch (Exception e)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os solicitantes");
		}
	}
}
