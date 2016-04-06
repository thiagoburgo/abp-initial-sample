using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Clintech.ClinApps.Domain.Entities.MultiTenancy;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Application.Entities.MultiTenancy
{
    public class CreateTenantInput : IInputDto
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }
    }
}