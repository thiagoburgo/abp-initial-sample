using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Clintech.ClinApps.Domain.Entities.Users;

namespace Clintech.ClinApps.Application.Entities.Sessions
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
