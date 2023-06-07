using Microsoft.EntityFrameworkCore;

namespace Data2TrackApiOpdracht.Class
{
    public class Data2TrackDbContext : DbContext
    {

        public DbSet<PoiLocation> PoiLocations { get; set; }
        public DbSet<PoiTypeAndTitle> PoiTypesAndTitles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1,3306;Database=data2track;User Id=root;Password=;");
            }
        }
    }
}
