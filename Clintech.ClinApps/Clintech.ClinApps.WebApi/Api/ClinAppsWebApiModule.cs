using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Castle.Core.Logging;
using Clintech.ClinApps.Application.Contracts;
using Clintech.ClinApps.Application.Contracts.Services;

namespace Clintech.ClinApps.WebApi.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ClinAppsApplicationContractsModule))]
    public class ClinAppsWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.Resolve<ILogger>().Info("ClinAppsWebApiModule");
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //DynamicApiControllerBuilder
            //    .ForAll<IApplicationService>(typeof(IRoleAppService).Assembly, "appUsers")
            //    .Where(type => type.Name.Contains("User"))
            //    .Build();

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(IRoleAppService).Assembly, "clinApps")
                //.Where(type => !type.Name.Contains("User"))
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
