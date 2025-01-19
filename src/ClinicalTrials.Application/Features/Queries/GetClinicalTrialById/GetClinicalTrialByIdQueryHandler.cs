using AutoMapper;
using ClinicalTrials.Application.Common.Interfaces;
using ClinicalTrials.Application.Features.Dtos;
using MediatR;

namespace ClinicalTrials.Application.Features.Queries.GetClinicalTrialById;

public class GetClinicalTrialByIdQueryHandler(IMapper mapper, IUnitOfWork repository)
    : IRequestHandler<GetClinicalTrialByIdQuery, ClinicalTrialDto>
{
    public async Task<ClinicalTrialDto> Handle(GetClinicalTrialByIdQuery query, CancellationToken cancellationToken)
    {
        var entity = await repository.ClinicalTrialRepository.GetAsync(e => e.TrialId == query.TrialId);
        if (entity is null) throw new KeyNotFoundException($"Clinical trial with Id {query.TrialId} not found");

        var result = mapper.Map<ClinicalTrialDto>(entity);
        return result;
    }
}