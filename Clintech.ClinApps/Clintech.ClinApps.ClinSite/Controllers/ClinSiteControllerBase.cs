using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Clintech.ClinApps.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace Clintech.ClinApps.ClinSite.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ClinSiteControllerBase : AbpController
    {
        protected ClinSiteControllerBase()
        {
            LocalizationSourceName = ClinAppsConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {   
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}