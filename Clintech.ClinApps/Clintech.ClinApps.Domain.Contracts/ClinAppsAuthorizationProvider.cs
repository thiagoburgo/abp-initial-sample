using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using Clintech.ClinApps.Domain.Entities;

namespace Clintech.ClinApps.Domain.Contracts
{
    public class ClinAppsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));
            
            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ClinAppsConsts.LocalizationSourceName);
        }
    }
}
