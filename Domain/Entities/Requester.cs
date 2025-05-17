using Domain.Validation;

namespace Domain.Entities;

public sealed class Requester
{
	public int RequesterId { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Cpf { get; set; } = string.Empty;

	public Requester(string name, string cpf)
	{
		ValidateDomain(name, cpf);
	}

	public Requester(int id, string name, string cpf)
	{
		DomainExceptionValidation.When(id < 0, "Valor de Id inválido");
		RequesterId = id;
		ValidateDomain(name, cpf);
	}

	public ICollection<Report> Reports { get; set; }

	private void ValidateDomain(string name, string cpf)
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório");
		DomainExceptionValidation.When(name.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");
		DomainExceptionValidation.When(name.Length > 100, "Nome inválido, muito longo, máximo de 100 caracteres");

		DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "CPF inválido. O CPF é obrigatório");
		DomainExceptionValidation.When(cpf.Length < 11, "CPF inválido, muito curto, mínimo de 11 caracteres");
		DomainExceptionValidation.When(cpf.Length > 11, "CPF inválido, muito longo, máximo de 11 caracteres");

		Name = name;
		Cpf = cpf;
	}
}
