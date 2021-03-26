using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace XYZ.Domain.UserAuthentication
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool MustChangePassword { get; set; }
        public virtual ICollection<ReservaHabitacion> ReservaHabitaciones { get; set; }

    }
}
