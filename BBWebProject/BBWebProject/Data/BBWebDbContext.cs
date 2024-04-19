using BBWebProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Data
{
    public class BBWebDbContext : DbContext
    {
        public BBWebDbContext(DbContextOptions<BBWebDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> tbl_item { get; set; }
    }
}
