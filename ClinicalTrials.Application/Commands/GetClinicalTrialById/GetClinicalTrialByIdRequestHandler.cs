using AutoMapper;
using ClinicalTrials.Application.Dtos;
using ClinicalTrials.Domain.Repositories;
using MediatR;

namespace ClinicalTrials.Application.Commands.GetClinicalTrialById;

public class GetClinicalTrialByIdRequestHandler(IMapper mapper, IUnitOfWork repository)
    : IRequestHandler<GetClinicalTrialByIdRequest, ClinicalTrialDto>
{
    public async Task<ClinicalTrialDto> Handle(GetClinicalTrialByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.ClinicalTrialRepository.GetAsync(e => e.TrialId == request.TrialId);
        if (entity is null) throw new KeyNotFoundException($"Clinical trial with Id {request.TrialId} not found");

        var result = mapper.Map<ClinicalTrialDto>(entity);
        return result;
    }
}