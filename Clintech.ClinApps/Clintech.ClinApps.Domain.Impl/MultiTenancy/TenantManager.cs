using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Clintech.ClinApps.Domain.Contracts.Services;
using Clintech.ClinApps.Domain.Entities.Authorization;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Clintech.ClinApps.Domain.Impl.Editions;

namespace Clintech.ClinApps.Domain.Impl.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>, ITenantManager
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}