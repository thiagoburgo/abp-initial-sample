using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using Clintech.ClinApps.Domain.Contracts.Services;

namespace Clintech.ClinApps.Domain.Impl.Editions
{
    public class EditionManager : AbpEditionManager, IEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository, 
            IRepository<EditionFeatureSetting, long> editionFeatureRepository)
            : base(
                editionRepository, 
                editionFeatureRepository
            )
        {
        }
    }
}
