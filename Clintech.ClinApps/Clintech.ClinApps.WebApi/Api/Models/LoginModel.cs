﻿using System.ComponentModel.DataAnnotations;

namespace Clintech.ClinApps.WebApi.Api.Models
{
    public class LoginModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}