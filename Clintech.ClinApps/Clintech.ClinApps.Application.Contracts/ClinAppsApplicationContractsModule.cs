using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Clintech.ClinApps.Domain.Contracts;
using Clintech.ClinApps.Repositories;

namespace Clintech.ClinApps.Application.Contracts
{
    [DependsOn(typeof(ClinAppsDomainContractsModule), 
        typeof(AbpAutoMapperModule),
        typeof(ClinAppsDataImplModule))]
    public class ClinAppsApplicationContractsModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
