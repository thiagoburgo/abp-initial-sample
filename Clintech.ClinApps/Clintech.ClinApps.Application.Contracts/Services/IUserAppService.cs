using System.Threading.Tasks;
using Abp.Application.Services;
using Clintech.ClinApps.Application.Entities.Users;

namespace Clintech.ClinApps.Application.Contracts.Services
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}