using Application.DTOs;
using Application.Mediator.Reports.Commands;
using Application.Mediator.Requesters.Commands;
using AutoMapper;

namespace Application.Mappings;

public class DtoToCommandMappingProfile : Profile
{
	public DtoToCommandMappingProfile()
	{
		CreateMap<ReportDto, ReportCreateCommand>();
		CreateMap<RequesterDto, RequesterCreateCommand>();
	}
}
