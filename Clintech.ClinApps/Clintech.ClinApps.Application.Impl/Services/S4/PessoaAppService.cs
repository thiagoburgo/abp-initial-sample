using Abp.AutoMapper;
using Clintech.ClinApps.Application.Contracts.Services.S4;
using Clintech.ClinApps.Application.Entities.S4;
using Clintech.ClinApps.Domain.Contracts.Services.S4;

namespace Clintech.ClinApps.Application.Impl.Services.S4
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService pessoaService;

        public PessoaAppService(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        public PessoaDto ConsultarPessoaAtivaPorId(int id)
        {
            return this.pessoaService.ConsultarPessoaAtivaPorId(id).MapTo<PessoaDto>();
        }
    }
}
