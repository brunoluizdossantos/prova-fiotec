﻿using Domain.Validation;

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
	public string IbgeCode { get; set; } = string.Empty;
	public string Geocode { get; set; } = string.Empty;

	public Report(DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		ValidateDomain(requestDate, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
	}

	public Report(int id, DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		DomainExceptionValidation.When(id < 0, "Valor de Id inválido");
		ReportId = id;
		ValidateDomain(requestDate, disease, startWeek, endWeek, startYear, endYear, ibgeCode, geocode);
	}

	private void ValidateDomain(DateTime requestDate, string disease, int startWeek, int endWeek, int startYear, int endYear, string ibgeCode, string geocode)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(disease), "Arbovirose inválido. Arbovirose é obrigatório");
		DomainExceptionValidation.When(disease.Length < 3, "Arbovirose inválido, muito curto, mínimo de 3 caracteres");
		DomainExceptionValidation.When(disease.Length > 50, "Arbovirose inválido, muito longo, máximo de 50 caracteres");

		DomainExceptionValidation.When(startWeek < 0, "Semana de início está inválido. Semana de início é obrigatório");

		DomainExceptionValidation.When(endWeek < 0, "Semana de término está inválido. Semana de término é obrigatório");

		DomainExceptionValidation.When(startYear < 0, "Ano de início está inválido. Ano de início é obrigatório");

		DomainExceptionValidation.When(endYear < 0, "Ano de término está inválido. Ano de término é obrigatório");

		DomainExceptionValidation.When(string.IsNullOrEmpty(ibgeCode), "Código IBGE inválido. Código IBGE é obrigatório");
		DomainExceptionValidation.When(disease.Length > 100, "Código IBGE inválido, muito longo, máximo de 50 caracteres");

		DomainExceptionValidation.When(string.IsNullOrEmpty(geocode), "Município inválido. Município é obrigatório");
		DomainExceptionValidation.When(geocode.Length > 100, "Município inválido, muito longo, máximo de 50 caracteres");

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
