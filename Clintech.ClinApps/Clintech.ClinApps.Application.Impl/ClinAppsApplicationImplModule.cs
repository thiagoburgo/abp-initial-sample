using System.Reflection;
using Abp.Modules;
using Clintech.ClinApps.Application.Contracts;

namespace Clintech.ClinApps.Application.Impl
{
    [DependsOn(typeof(ClinAppsApplicationContractsModule))]
    public class ClinAppsApplicationImplModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
