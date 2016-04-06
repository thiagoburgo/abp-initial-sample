using System.Web.Mvc;

namespace Clintech.ClinApps.ClinSite.Controllers
{
    public class AboutController : ClinSiteControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}