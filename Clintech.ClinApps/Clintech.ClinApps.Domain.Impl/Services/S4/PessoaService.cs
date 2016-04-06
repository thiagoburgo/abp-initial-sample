using Abp.Domain.Repositories;
using Clintech.ClinApps.Domain.Contracts.Repositories;
using Clintech.ClinApps.Domain.Contracts.Services.S4;
using Clintech.ClinApps.Domain.Entities.S4;

namespace Clintech.ClinApps.Domain.Impl.Services.S4
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        //private readonly IRepository<Pessoa> pessoaRepository2;

        public PessoaService(IPessoaRepository pessoaRepository/*, IRepository<Pessoa> pessoaRepository2*/)
        {
            this.pessoaRepository = pessoaRepository;
            //this.pessoaRepository2 = pessoaRepository2;
        }

        public Pessoa ConsultarPessoaAtivaPorId(int id)
        {
            //return pessoaRepository2.Get(id);
            return pessoaRepository.Get(id);
        }
    }
}
