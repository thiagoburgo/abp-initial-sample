using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Clintech.ClinApps.Domain.Entities.S4;

namespace Clintech.ClinApps.Application.Entities.S4
{
    [AutoMap(typeof(Pessoa))]
    public class PessoaDto : EntityDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}