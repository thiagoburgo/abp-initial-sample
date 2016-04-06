using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Events.Bus.Entities;
using Abp.Localization;
using Abp.Runtime.Caching;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface ITenantManager
    {
        Task<IdentityResult> CreateAsync(Tenant tenant);
        Task<IdentityResult> UpdateAsync(Tenant tenant);
        Task<Tenant> FindByIdAsync(int id);
        Task<Tenant> GetByIdAsync(int id);
        Task<Tenant> FindByTenancyNameAsync(string tenancyName);
        Task<IdentityResult> DeleteAsync(Tenant tenant);
        Task<string> GetFeatureValueOrNullAsync(int tenantId, string featureName);
        Task<IReadOnlyList<NameValue>> GetFeatureValuesAsync(int tenantId);
        Task SetFeatureValuesAsync(int tenantId, params NameValue[] values);
        Task SetFeatureValueAsync(int tenantId, string featureName, string value);
        Task SetFeatureValueAsync(Tenant tenant, string featureName, string value);
        Task ResetAllFeaturesAsync(int tenantId);
        void HandleEvent(EntityChangedEventData<Tenant> eventData);
        void HandleEvent(EntityDeletedEventData<Edition> eventData);
        AbpEditionManager EditionManager { get; set; }
        ILocalizationManager LocalizationManager { get; set; }
        ICacheManager CacheManager { get; set; }
        IFeatureManager FeatureManager { get; set; }
        IQueryable<Tenant> Tenants { get; }
    }
}