using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration;

public class RequesterConfiguration : IEntityTypeConfiguration<Requester>
{
	public void Configure(EntityTypeBuilder<Requester> builder)
	{
		builder.HasKey(t => t.RequesterId);

		builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
		builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
	}
}
