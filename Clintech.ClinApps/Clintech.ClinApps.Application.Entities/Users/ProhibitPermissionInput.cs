using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Clintech.ClinApps.Application.Entities.Users
{
    public class ProhibitPermissionInput : IInputDto
    {
        [Range(1, long.MaxValue)]
        public int UserId { get; set; }

        [Required]
        public string PermissionName { get; set; }
    }
}