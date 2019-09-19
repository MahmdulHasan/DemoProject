using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Entities
{
    public class Role
           : IdentityRole<Guid>, IEntity<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
