using AutoMapper;
using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.Data.Entities.Base;
using ClinicalTrials.Contracts.DTO;
using ClinicalTrials.Contracts.DTO.Base;

namespace ClinicalTrials.Core.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BaseEntity, BaseEntityVM>();
        CreateMap<ClinicalTrial, ClinicalTrialVM>();
    }
}