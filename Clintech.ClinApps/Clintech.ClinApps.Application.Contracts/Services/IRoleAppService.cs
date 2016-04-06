using System.Threading.Tasks;
using Abp.Application.Services;
using Clintech.ClinApps.Application.Entities.Roles;

namespace Clintech.ClinApps.Application.Contracts.Services
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
