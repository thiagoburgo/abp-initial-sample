using Abp.Application.Navigation;
using Abp.Localization;
using Clintech.ClinApps.Domain.Entities;
using Clintech.ClinApps.Domain.Entities.Authorization;

namespace Clintech.ClinApps.ClinSite
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class ClinSiteNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        L("HomePage"),
                        url: "/ClinSite/Home",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "/ClinSite/Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "/ClinSite/About",
                        icon: "fa fa-info"
                        )
                );
            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ClinAppsConsts.LocalizationSourceName);
        }
    }
}
