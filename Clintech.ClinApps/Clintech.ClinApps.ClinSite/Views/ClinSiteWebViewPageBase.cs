using Abp.Web.Mvc.Views;
using Clintech.ClinApps.Domain.Entities;

namespace Clintech.ClinApps.ClinSite.Views
{
    public abstract class ClinSiteWebViewPageBase : ClinSiteWebViewPageBase<dynamic>
    {

    }

    public abstract class ClinSiteWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ClinSiteWebViewPageBase()
        {
            LocalizationSourceName = ClinAppsConsts.LocalizationSourceName;
        }
    }
}