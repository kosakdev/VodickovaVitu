using Microsoft.EntityFrameworkCore;

namespace CMS.DAL
{
    public class WebDataContext : DbContext
    {
        public WebDataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        // public virtual DbSet<Entitz> Name { get; set; }
        
    }
}