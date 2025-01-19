using System.Linq.Expressions;
using AutoMapper;
using ClinicalTrials.Application.Common.Helpers;
using ClinicalTrials.Application.Common.Interfaces;
using ClinicalTrials.Application.Features.Dtos;
using ClinicalTrials.Application.Features.Models.Responses;
using ClinicalTrials.Domain.Entities;
using ClinicalTrials.Domain.Enums;
using MediatR;

namespace ClinicalTrials.Application.Features.Queries.GetClinicalTrials;

public class GetClinicalTrialsQueryHandler(IMapper mapper, IUnitOfWork repository)
    : IRequestHandler<GetClinicalTrialsQuery, ClinicalTrialsFilterResponse>
{
    public async Task<ClinicalTrialsFilterResponse> Handle(GetClinicalTrialsQuery query,
        CancellationToken cancellationToken)
    {
        Expression<Func<ClinicalTrial, bool>> _expr = e =>
            e.EntityStatus == EntityStatus.Active;

        if (query.FilterRequest.Keyword is not null)
            _expr = _expr.AndAlso(e => e.Title.Contains(query.FilterRequest.Keyword));

        if (query.FilterRequest.Status is not null)
            _expr = _expr.AndAlso(e => e.Status == query.FilterRequest.Status);

        var entities =
            await repository.ClinicalTrialRepository.GetAllAsync(_expr,
                (query.FilterRequest.Page - 1) * query.FilterRequest.PageSize,
                query.FilterRequest.PageSize, e => e.CreatedAt,
                query.FilterRequest.IsDescending);

        var count = await repository.ClinicalTrialRepository.CountAsync(_expr);
        var totalPages = (int)Math.Ceiling(decimal.Divide(count, query.FilterRequest.PageSize));

        var сlinicalTrials = mapper.Map<List<ClinicalTrialDto>>(entities);

        var result = new ClinicalTrialsFilterResponse
        {
            ClinicalTrials = сlinicalTrials,
            Page = query.FilterRequest.Page,
            PageSize = query.FilterRequest.PageSize,
            TotalCount = count,
            ShowPrevious = query.FilterRequest.Page > 1,
            ShowNext = query.FilterRequest.Page < totalPages
        };

        return result;
    }
}