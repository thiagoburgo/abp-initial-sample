using System.Data.Common;
using Abp.Domain.Repositories;
using Abp.EntityFramework.Repositories;
using Abp.Zero.EntityFramework;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Clintech.ClinApps.Repositories.Repositories;

namespace Clintech.ClinApps.Repositories.DbContexts
    {
        [AutoRepositoryTypes(
               typeof(IRepository<>),
               typeof(IRepository<,>),
               typeof(ClinAppsRepositoryBase<>),
               typeof(ClinAppsRepositoryBase<,>)
               )]
        public class ClinAppsDbContext : AbpZeroDbContext<Tenant, Role, User>
        {
        public ClinAppsDbContext()
             : base("Default")
        {
        }

        public ClinAppsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ClinAppsDbContext(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}
