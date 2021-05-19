using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CMS.DAL.Entities
{
    [Table("AspNetUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        
    }
}