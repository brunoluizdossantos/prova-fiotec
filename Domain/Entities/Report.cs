using Domain.Validation;

namespace Domain.Entities;

public sealed class Report
{
	public int ReportId { get; set; }
	public DateTime RequestDate { get; set; }
	public string Disease { get; set; } = string.Empty;
	public int StartWeek { get; set; }
	public int EndWeek { get; set; }
	public int StartYear { get; set; }
	public int EndYear { get; set; }
	public int IbgeCode { get; set; }
	public int Geocode { get; set; }

	public Report(DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, int ibgeCode, int geocode)
	{
		ValidateDomain(requestDate, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
	}

	public Report(int id, DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, int ibgeCode, int geocode)
	{
		DomainExceptionValidation.When(id < 0, "Valor de Id inválido");
		ReportId = id;
		ValidateDomain(requestDate, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
	}

	private void ValidateDomain(DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, int ibgeCode, int geocode)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(disease), "Arbovirose inválido. Arbovirose é obrigatório");
		DomainExceptionValidation.When(disease.Length < 3, "Arbovirose inválido, muito curto, mínimo de 3 caracteres");
		DomainExceptionValidation.When(disease.Length > 50, "Arbovirose inválido, muito longo, máximo de 50 caracteres");

		DomainExceptionValidation.When(startWeek < 0, "Semana de início está inválido. Semana de início é obrigatório");

		DomainExceptionValidation.When(endWeek < 0, "Semana de término está inválido. Semana de término é obrigatório");

		DomainExceptionValidation.When(startYear < 0, "Ano de início está inválido. Ano de início é obrigatório");

		DomainExceptionValidation.When(endYear < 0, "Ano de término está inválido. Ano de término é obrigatório");

		DomainExceptionValidation.When(ibgeCode < 0, "Código IBGE está inválido. Código IBGE é obrigatório");

		DomainExceptionValidation.When(geocode < 0, "Município está inválido. Município é obrigatório");

		RequestDate = requestDate;
		Disease = disease;
		StartWeek = startWeek;
		EndWeek = endWeek;
		StartYear = startYear;
		EndYear = endYear;
		IbgeCode = ibgeCode;
		Geocode = geocode;
	}

	public int RequesterId { get; set; }
	public Requester Requester { get; set; }
}
