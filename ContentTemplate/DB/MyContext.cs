

using Microsoft.EntityFrameworkCore;

namespace ContentTemplate.DB
{
    public class MyContext : DbContext 
    {
        string cs =
             "Server=192.168.49.180; Database=Ahtyamov_07_04;" +
             "user id = stud; password=stud;TrustServerCertificate = true";

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

    }
}
