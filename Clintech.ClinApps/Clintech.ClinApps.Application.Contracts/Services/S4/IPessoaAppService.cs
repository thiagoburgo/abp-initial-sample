using Abp.Application.Services;
using Clintech.ClinApps.Application.Entities.S4;

namespace Clintech.ClinApps.Application.Contracts.Services.S4
{
    public interface IPessoaAppService : IApplicationService
    {
        PessoaDto ConsultarPessoaAtivaPorId(int id);
    }
}
