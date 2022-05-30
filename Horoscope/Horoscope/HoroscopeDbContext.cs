using Horoscope.Domain;
using Microsoft.EntityFrameworkCore;

namespace Horoscope
{
    public class HoroscopeDbContext : DbContext
    {
        public HoroscopeDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverConnectionString = "Server=localhost;Database=Horoscope;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(serverConnectionString);
        }

        public DbSet<Student> Students { get; set; }
    }
}
