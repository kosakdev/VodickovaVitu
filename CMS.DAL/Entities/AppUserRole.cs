using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CMS.DAL.Entities
{
    [Table("AspNetUserRoles")]
    public class AppUserRole : IdentityUserRole<Guid>
    {
        
    }
}