using AutoMapper;
using ClinicalTrials.Application.Features.Dtos;
using ClinicalTrials.Domain.Entities;

namespace ClinicalTrials.Application.Common;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BaseEntity, BaseEntityDto>();
        CreateMap<ClinicalTrial, ClinicalTrialDto>();
    }
}