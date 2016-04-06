using System.Threading.Tasks;
using Abp.Application.Services;
using Clintech.ClinApps.Application.Entities.Sessions;

namespace Clintech.ClinApps.Application.Contracts.Services
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
