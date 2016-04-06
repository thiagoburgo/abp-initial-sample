using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace Clintech.ClinApps.Domain.Contracts
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ClinAppsDomainContractsModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
