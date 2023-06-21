using Microsoft.EntityFrameworkCore;
using Task_Management.Models;
using Task_Management.Models.NewFolder;

namespace Task_Management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        } 

        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> tasks { get; set; }
        public DbSet<Assignedto> assignedto { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
