using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Data
{
    public class BBWebDbContext : DbContext
    {
        public BBWebDbContext(DbContextOptions<BBWebDbContext> options) : base(options)
        {
            
        }
    }
}
