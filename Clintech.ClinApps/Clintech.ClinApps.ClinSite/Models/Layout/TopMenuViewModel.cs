using Abp.Application.Navigation;

namespace Clintech.ClinApps.ClinSite.Models.Layout
{
    public class TopMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}