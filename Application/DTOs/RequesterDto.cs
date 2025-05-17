using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTOs;

public class RequesterDto
{
	[JsonIgnore]
	public int RequesterId { get; set; }

	[Required(ErrorMessage = "O nome é obrigatório")]
	[MinLength(3)]
	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;

	[Required(ErrorMessage = "O CPF é obrigatório")]
	[MinLength(11)]
	public string Cpf { get; set; } = String.Empty;
}