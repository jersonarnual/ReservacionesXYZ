using Microsoft.AspNetCore.Identity;
using System;

namespace XYZ.Domain.UserAuthentication
{
    public class ApplicationUser : IdentityUser
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool MustChangePassword { get; set; }
    }
}
