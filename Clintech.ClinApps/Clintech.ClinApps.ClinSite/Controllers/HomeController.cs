using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Clintech.ClinApps.ClinSite.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ClinSiteControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}