using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Clintech.ClinApps.Repositories.DbContexts;

namespace Clintech.ClinApps.Repositories.Repositories
{
    public class ClinAppsRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ClinAppsDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ClinAppsRepositoryBase(IDbContextProvider<ClinAppsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {   
        }
        //add common methods for all repositories
    }

    public class ClinAppsRepositoryBase<TEntity> : ClinAppsRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ClinAppsRepositoryBase(IDbContextProvider<ClinAppsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //do not add any method here, add to the class above (since this inherits it)
    }
}
