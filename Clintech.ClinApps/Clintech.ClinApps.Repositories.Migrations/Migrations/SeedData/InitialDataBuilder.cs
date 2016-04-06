using Clintech.ClinApps.Repositories.DbContexts;
using EntityFramework.DynamicFilters;

namespace Clintech.ClinApps.Repositories.Migrations.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly ClinAppsDbContext _context;

        public InitialDataBuilder(ClinAppsDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
