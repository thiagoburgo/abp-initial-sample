using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Clintech.ClinApps.Application.Contracts.Services;
using Clintech.ClinApps.Domain.Entities.Authorization;

namespace Clintech.ClinApps.ClinSite.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : ClinSiteControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}