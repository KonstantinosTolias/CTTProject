using CTTProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CTTProject.Migrations
{
    public class ProjectDb : DbContext
    {
        public DbSet<Backer> Backers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Funds> Funds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(local);Initial Catalog=Project_Cloud;Integrated Security = true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}

