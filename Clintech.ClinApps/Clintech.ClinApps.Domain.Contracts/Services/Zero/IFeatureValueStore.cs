using System.Threading.Tasks;
using Abp.Application.Features;

namespace Clintech.ClinApps.Domain.Contracts.Services
{
    public interface IFeatureValueStore
    {
        Task<string> GetValueOrNullAsync(int tenantId, Feature feature);
    }
}