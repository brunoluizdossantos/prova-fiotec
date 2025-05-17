using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Integration;
using Application.Mediator.Reports.Commands;
using Application.Mediator.Requesters.Commands;
using Application.Mediator.Requesters.Queries;
using AutoMapper;
using MediatR;

namespace Application.Services;

public class InfoDengueService : IInfoDengueService
{
	private readonly IInfoDengueIntegrationService _infoDengueIntegrationService;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	private readonly string _ibgeCodeRJ = "33";
	private readonly string _geocodeRJ = "3304557";

	private readonly string _ibgeCodeSP = "35";
	private readonly string _geocodeSP = "3550308";

	private readonly string _diseaseDengue = "dengue";
	private readonly string _diseaseChikungunya = "chikungunya";
	private readonly string _diseaseZika = "zika";

	public InfoDengueService(IInfoDengueIntegrationService infoDengueIntegrationService, IMapper mapper, IMediator mediator)
	{
		_infoDengueIntegrationService = infoDengueIntegrationService;
		_mapper = mapper;
		_mediator = mediator;
	}

	public async Task<IEnumerable<InfoDengueDto>> GetDataInfoDengue(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		if (disease.Length == 0)
		{
			await this.CreateRequesterAndReport(name, cpf, $"{_diseaseDengue}|{_diseaseChikungunya}|{_diseaseZika}", startWeek, endWeek, startYear, endYear, ibgeCode, geocode);

			return await this.GetDataInfoDengueByAllDeseases(name, cpf, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
		}
		else
		{
			await this.CreateRequesterAndReport(name, cpf, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);

			return await this.GetDataInfoDengueByUniqueDesease(name, cpf, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
		}
	}

	public async Task<IEnumerable<InfoDengueDto>> GetDataInfoDengueByGeocodeRJSP(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear)
	{
		await this.CreateRequesterAndReport(name, cpf, $"{_diseaseDengue}|{_diseaseChikungunya}|{_diseaseZika}", startWeek, endWeek, startYear, endYear, $"{_ibgeCodeRJ}|{_ibgeCodeSP}", $"{_geocodeRJ}|{_geocodeSP}");

		var responseRJ = await this.GetDataInfoDengueByAllDeseases(name, cpf, startWeek, endWeek, startYear, endYear, _ibgeCodeRJ, _geocodeRJ);
		var responseSP = await this.GetDataInfoDengueByAllDeseases(name, cpf, startWeek, endWeek, startYear, endYear, _ibgeCodeSP, _geocodeSP);
		
		var responseFinal = (responseRJ).Concat(responseSP);

		if (responseFinal != null)
			return responseFinal;

		return null;
	}

	private async Task CreateRequesterAndReport(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		var requesterId = await this.CreateRequester(name, cpf);

		if (requesterId == 0)
			return;

		var dto = new ReportDto()
		{
			RequestDate = DateTime.Now,
			Disease = disease,
			StartWeek = startWeek,
			EndWeek = endWeek,
			StartYear = startYear,
			EndYear = endYear,
			IbgeCode = ibgeCode,
			Geocode = geocode,
			RequesterId = requesterId
		};
		var query = _mapper.Map<ReportCreateCommand>(dto);
		var result = await _mediator.Send(query);
	}

	private async Task<int> CreateRequester(string name, string cpf)
	{
		var requesterExists = await this.CheckIfRequesterExists(cpf);

		if (requesterExists != null)
		{
			return requesterExists.RequesterId;
		}
		else
		{
			var dto = new RequesterDto()
			{
				Name = name,
				Cpf = cpf
			};
			var query = _mapper.Map<RequesterCreateCommand>(dto);
			var result = await _mediator.Send(query);
			return result.RequesterId;
		}
	}

	private async Task<RequesterDto> CheckIfRequesterExists(string cpf)
	{
		var query = new GetRequesterByCpfQuery(cpf) ?? throw new NullReferenceException("Não foi possível carregar a entidade");
		var result = await _mediator.Send(query);
		return _mapper.Map<RequesterDto>(result);
	}

	private async Task<IEnumerable<InfoDengueDto>> GetDataInfoDengueByAllDeseases(string name, string cpf, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		var responseDengue = await this.GetDataInfoDengueByUniqueDesease(name, cpf, _diseaseDengue, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
		var responseChikungunya = await this.GetDataInfoDengueByUniqueDesease(name, cpf, _diseaseChikungunya, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
		var responseZika = await this.GetDataInfoDengueByUniqueDesease(name, cpf, _diseaseZika, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);

		var responseFinal = (responseDengue).Concat(responseChikungunya).Concat(responseZika);

		if (responseFinal != null)
			return responseFinal;

		return null;
	}

	private async Task<IEnumerable<InfoDengueDto>> GetDataInfoDengueByUniqueDesease(string name, string cpf, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		var response = await _infoDengueIntegrationService.GetDataInfoDengue(Convert.ToInt32(geocode), disease, startWeek, endWeek, startYear, endYear);

		if (response != null && response.IsSuccessStatusCode)
			return response.Content;

		return null;
	}
}
