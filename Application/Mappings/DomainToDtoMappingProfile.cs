using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class DomainToDtoMappingProfile : AutoMapper.Profile
{
	public DomainToDtoMappingProfile()
	{
		CreateMap<Report, ReportDto>().ReverseMap();
		CreateMap<Requester, RequesterDto>().ReverseMap();
	}
}
