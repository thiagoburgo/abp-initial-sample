using System.Data.Entity.Migrations;
using Clintech.ClinApps.Repositories.DbContexts;
using Clintech.ClinApps.Repositories.Migrations.Migrations.SeedData;

namespace Clintech.ClinApps.Repositories.Migrations.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ClinAppsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ClinApps";
        }

        protected override void Seed(ClinAppsDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
