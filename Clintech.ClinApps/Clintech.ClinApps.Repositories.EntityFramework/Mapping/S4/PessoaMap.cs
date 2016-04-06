using System.Data.Entity.ModelConfiguration;
using Clintech.ClinApps.Domain.Entities.S4;

namespace Clintech.ClinApps.Repositories.Mapping.S4
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");
            Property(p => p.Id).HasColumnName("Id");
            Property(p => p.Nome).HasColumnName("Nome");
            Property(p => p.Idade).HasColumnName("Idade");
        }
    }
}
