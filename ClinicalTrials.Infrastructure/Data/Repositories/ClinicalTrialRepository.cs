using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.Data.Repositories;
using ClinicalTrials.Migrations;

namespace ClinicalTrials.Infrastructure.Data.Repositories;

public class ClinicalTrialRepository(DatabaseContext context) : Repository<ClinicalTrial>(context), IClinicalTrialRepository;
