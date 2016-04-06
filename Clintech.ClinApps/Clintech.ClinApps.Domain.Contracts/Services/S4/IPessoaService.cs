using Abp.Domain.Services;
using Clintech.ClinApps.Domain.Entities.S4;

namespace Clintech.ClinApps.Domain.Contracts.Services.S4
{
    public interface IPessoaService : IDomainService
    {
        Pessoa ConsultarPessoaAtivaPorId(int id);
    }
}
