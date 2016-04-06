using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Clintech.ClinApps.Domain.Contracts;

namespace Clintech.ClinApps.Repositories
{
    [DependsOn(typeof(AbpEntityFrameworkModule),typeof(AbpZeroEntityFrameworkModule), 
        typeof(ClinAppsDomainContractsModule))]
    
    public class ClinAppsDataImplModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
