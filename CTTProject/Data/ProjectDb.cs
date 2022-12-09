using CTTProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CTTProject.Migrations
{
    public class ProjectDb : DbContext
    {
        public ProjectDb(DbContextOptions<ProjectDb> options) : base(options)
        {

        }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Funds> Funds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=tcp:team-7.database.windows.net,1433;Initial Catalog=Project_Cloud;Persist Security Info=False;User ID=Team7;Password=123456!a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}

