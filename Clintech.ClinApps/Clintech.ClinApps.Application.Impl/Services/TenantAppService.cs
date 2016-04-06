using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using Clintech.ClinApps.Application.Contracts.Services;
using Clintech.ClinApps.Application.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Contracts;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;
using Clintech.ClinApps.Domain.Impl.Authorization.Roles;
using Clintech.ClinApps.Domain.Impl.Editions;
using Clintech.ClinApps.Domain.Impl.MultiTenancy;

namespace Clintech.ClinApps.Application.Impl.Services
{
    [AbpAuthorize]
    [Audited]
    public class TenantAppService : ApplicationServiceBase, ITenantAppService
    {
        private readonly TenantManager _tenantManager;
        private readonly RoleManager _roleManager;
        private readonly EditionManager _editionManager;

        public TenantAppService(TenantManager tenantManager, RoleManager roleManager, EditionManager editionManager)
        {
            _tenantManager = tenantManager;
            _roleManager = roleManager;
            _editionManager = editionManager;
        }

        [Audited]
        public ListResultOutput<TenantListDto> GetTenants()
        {
            return new ListResultOutput<TenantListDto>(
                _tenantManager.Tenants
                    .OrderBy(t => t.TenancyName)
                    .ToList()
                    .MapTo<List<TenantListDto>>()
                );
        }

        [Audited]
        public async Task CreateTenant(CreateTenantInput input)
        {
            //Create tenant
            var tenant = new Tenant(input.TenancyName, input.Name);
            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            CheckErrors(await TenantManager.CreateAsync(tenant));
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new tenant's id.

            //We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, tenant.Id))
            {
                //Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync(); //To get static role ids

                //grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                //Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress, User.DefaultPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync(); //To get admin user's id

                //Assign admin user to role!
                CheckErrors(await UserManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }
    }
}