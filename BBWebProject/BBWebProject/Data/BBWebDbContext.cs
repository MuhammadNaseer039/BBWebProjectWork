using BBWebProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BBWebProject.Data
{
    public class BBWebDbContext : DbContext
    {
        public BBWebDbContext(DbContextOptions<BBWebDbContext> options) : base(options)
        {
            
        }

        public DbSet<Non_Variated_Items> tbl_non_variated_items { get; set; }
        public DbSet<Testimonial> tbl_testimonials { get; set; }
        public DbSet<Chief> tbl_chief { get; set;}
        public DbSet<Profile> tbl_profile { get; set; }
        public DbSet<Category> tbl_category { get; set; }
        public DbSet<Variated_Items> tbl_variated_items { get; set; }
        public DbSet<User> tbl_users {  get; set; }
    }
}
