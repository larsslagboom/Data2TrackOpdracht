using Data2TrackApiOpdracht.Class;

namespace Data2TrackApiOpdracht
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data2TrackDbContext>();
        }
    }
}
