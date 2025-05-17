using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
	public void Configure(EntityTypeBuilder<Report> builder)
	{
		builder.HasKey(t => t.ReportId);

		builder.Property(p => p.Disease).HasMaxLength(50).IsRequired();
		builder.Property(p => p.StartWeek).IsRequired();
		builder.Property(p => p.EndWeek).IsRequired();
		builder.Property(p => p.StartYear).IsRequired();
		builder.Property(p => p.EndYear).IsRequired();
		builder.Property(p => p.IbgeCode).HasMaxLength(100).IsRequired();
		builder.Property(p => p.Geocode).HasMaxLength(100).IsRequired();

		builder.HasOne(e => e.Requester).WithMany(e => e.Reports).HasForeignKey(e => e.RequesterId);
	}
}
