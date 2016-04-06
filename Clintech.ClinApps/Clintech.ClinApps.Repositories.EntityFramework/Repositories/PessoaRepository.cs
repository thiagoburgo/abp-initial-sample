using Abp.EntityFramework;
using Clintech.ClinApps.Domain.Contracts.Repositories;
using Clintech.ClinApps.Domain.Entities.S4;
using Clintech.ClinApps.Repositories.DbContexts;

namespace Clintech.ClinApps.Repositories.Repositories
{
    public class PessoaRepository : S4RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(IDbContextProvider<S4DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
}
