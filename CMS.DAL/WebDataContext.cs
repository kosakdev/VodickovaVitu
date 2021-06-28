using System;
using CMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL
{
    public class WebDataContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>,
        AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public WebDataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public virtual DbSet<ArticleEntity> Article { get; set; }
        
        public virtual DbSet<CalendarEntity> Calendar { get; set; }
        public virtual DbSet<MusicEntity> Music { get; set; }
    }
}