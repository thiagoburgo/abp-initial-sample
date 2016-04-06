using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Events.Bus.Entities;
using Abp.Runtime.Caching;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IEditionManager
    {
        Task<string> GetFeatureValueOrNullAsync(int editionId, string featureName);
        Task SetFeatureValueAsync(int editionId, string featureName, string value);
        Task<IReadOnlyList<NameValue>> GetFeatureValuesAsync(int editionId);
        Task SetFeatureValuesAsync(int editionId, params NameValue[] values);
        Task CreateAsync(Edition edition);
        Task<Edition> FindByNameAsync(string name);
        Task<Edition> FindByIdAsync(int id);
        Task<Edition> GetByIdAsync(int id);
        Task DeleteAsync(Edition edition);
        void HandleEvent(EntityChangedEventData<EditionFeatureSetting> eventData);
        void HandleEvent(EntityChangedEventData<Edition> eventData);
        IQueryable<Edition> Editions { get; }
        ICacheManager CacheManager { get; set; }
        IFeatureManager FeatureManager { get; set; }
    }
}