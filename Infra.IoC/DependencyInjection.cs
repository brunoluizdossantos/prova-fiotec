using Application.Interfaces;
using Application.Interfaces.Integration;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infra.IoC;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
			b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

		services.AddScoped<IReportRepository, ReportRepository>();
		services.AddScoped<IRequesterRepository, RequesterRepository>();

		services.AddScoped<IInfoDengueService, InfoDengueService>();
		services.AddScoped<IReportService, ReportService>();
		services.AddScoped<IRequesterService, RequesterService>();

		services.AddRefitClient<IInfoDengueIntegrationService>().ConfigureHttpClient(c =>
		{
			c.BaseAddress = new Uri("https://info.dengue.mat.br");
		});

		services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

		services.AddMediatR(AppDomain.CurrentDomain.Load("Application"));

		return services;
	}
}
