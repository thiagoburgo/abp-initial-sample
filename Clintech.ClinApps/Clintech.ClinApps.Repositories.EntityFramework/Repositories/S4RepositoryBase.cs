using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Clintech.ClinApps.Repositories.DbContexts;

namespace Clintech.ClinApps.Repositories.Repositories
{
    public abstract class S4RepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<S4DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected S4RepositoryBase(IDbContextProvider<S4DbContext> dbContextProvider)
            : base(dbContextProvider)
        {   
        }
        //add common methods for all repositories
    }

    public abstract class S4RepositoryBase<TEntity> : S4RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected S4RepositoryBase(IDbContextProvider<S4DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //do not add any method here, add to the class above (since this inherits it)
    }
}
