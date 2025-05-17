using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ReportDto
{
	//public int ReportId { get; set; }

	public DateTime RequestDate { get; set; }

	[Required(ErrorMessage = "O arbovirose é obrigatório")]
	[MinLength(3)]
	[MaxLength(50)]
	public string Disease { get; set; } = string.Empty;

	[Required(ErrorMessage = "A semana de início é obrigatório")]
	public int StartWeek { get; set; }

	[Required(ErrorMessage = "A semana de término é obrigatório")]
	public int EndWeek { get; set; }

	[Required(ErrorMessage = "O ano de início é obrigatório")]
	public int StartYear { get; set; }

	[Required(ErrorMessage = "O ano de término é obrigatório")]
	public int EndYear { get; set; }

	[Required(ErrorMessage = "O Código IBGE é obrigatório")]
	public int IbgeCode { get; set; }

	[Required(ErrorMessage = "O Município é obrigatório")]
	public int Geocode { get; set; }

	public int RequesterId { get; set; }

	[Required(ErrorMessage = "O nome é obrigatório")]
	[MinLength(3)]
	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;

	[Required(ErrorMessage = "O CPF é obrigatório")]
	[MinLength(11)]
	public string Cpf { get; set; } = String.Empty;
}