using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero.Configuration;
using Clintech.ClinApps.Domain.Contracts;
using Clintech.ClinApps.Domain.Entities;

namespace Clintech.ClinApps.Domain.Impl
{
    [DependsOn(typeof(ClinAppsDomainContractsModule))]
    public class ClinAppsDomainImplModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    ClinAppsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Clintech.ClinApps.Domain.Impl.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<ClinAppsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
