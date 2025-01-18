using System.Linq.Expressions;
using AutoMapper;
using ClinicalTrials.Application.Common.Helpers;
using ClinicalTrials.Application.Dtos;
using ClinicalTrials.Application.Models.Responses;
using ClinicalTrials.Domain.Entities;
using ClinicalTrials.Domain.Enums;
using ClinicalTrials.Domain.Repositories;
using MediatR;

namespace ClinicalTrials.Application.Commands.GetClinicalTrials;

public class GetClinicalTrialsRequestHandler(IMapper mapper, IUnitOfWork repository)
    : IRequestHandler<GetClinicalTrialsRequest, ClinicalTrialsFilterResponse>
{
    public async Task<ClinicalTrialsFilterResponse> Handle(GetClinicalTrialsRequest request,
        CancellationToken cancellationToken)
    {
        Expression<Func<ClinicalTrial, bool>> _expr = e =>
            e.EntityStatus == EntityStatus.Active;

        if (request.FilterRequest.Keyword is not null)
            _expr = _expr.AndAlso(e => e.Title.Contains(request.FilterRequest.Keyword));

        if (request.FilterRequest.Status is not null)
            _expr = _expr.AndAlso(e => e.Status == request.FilterRequest.Status);

        var entities =
            await repository.ClinicalTrialRepository.GetAllAsync(_expr,
                (request.FilterRequest.Page - 1) * request.FilterRequest.PageSize,
                request.FilterRequest.PageSize, e => e.CreatedAt,
                request.FilterRequest.IsDescending);

        var count = await repository.ClinicalTrialRepository.CountAsync(_expr);
        var totalPages = (int)Math.Ceiling(decimal.Divide(count, request.FilterRequest.PageSize));

        var сlinicalTrials = mapper.Map<List<ClinicalTrialDto>>(entities);

        var result = new ClinicalTrialsFilterResponse
        {
            ClinicalTrials = сlinicalTrials,
            Page = request.FilterRequest.Page,
            PageSize = request.FilterRequest.PageSize,
            TotalCount = count,
            ShowPrevious = request.FilterRequest.Page > 1,
            ShowNext = request.FilterRequest.Page < totalPages
        };

        return result;
    }
}