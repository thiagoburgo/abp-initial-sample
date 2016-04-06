using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Clintech.ClinApps.Application.Entities.MultiTenancy;

namespace Clintech.ClinApps.Application.Contracts.Services
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
