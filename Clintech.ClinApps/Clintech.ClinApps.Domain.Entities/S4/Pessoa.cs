using Abp.Domain.Entities;

namespace Clintech.ClinApps.Domain.Entities.S4
{
    public class Pessoa : Entity<int>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
