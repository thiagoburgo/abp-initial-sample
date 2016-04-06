using Abp.Application.Features;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Clintech.ClinApps.Domain.Impl.MultiTenancy;
using IFeatureValueStore = Clintech.ClinApps.Domain.Contracts.Services.IFeatureValueStore;

namespace Clintech.ClinApps.Domain.Impl.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>, IFeatureValueStore
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}