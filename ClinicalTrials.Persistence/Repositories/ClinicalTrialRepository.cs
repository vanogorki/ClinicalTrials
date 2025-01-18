using ClinicalTrials.Domain.Entities;
using ClinicalTrials.Domain.Repositories;

namespace ClinicalTrials.Persistence.Repositories;

public sealed class ClinicalTrialRepository(DatabaseContext context)
    : Repository<ClinicalTrial>(context), IClinicalTrialRepository;