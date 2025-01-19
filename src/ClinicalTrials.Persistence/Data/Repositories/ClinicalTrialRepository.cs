using ClinicalTrials.Application.Common.Interfaces;
using ClinicalTrials.Domain.Entities;

namespace ClinicalTrials.Persistence.Data.Repositories;

public sealed class ClinicalTrialRepository(DatabaseContext context)
    : Repository<ClinicalTrial>(context), IClinicalTrialRepository;