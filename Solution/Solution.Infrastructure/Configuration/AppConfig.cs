using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

namespace Solution.Infrastructure.Configuration
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration contfiguration)
        {
            _configuration = contfiguration;
        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public string GetExternalApiUrl()
        {
            return _configuration["ExternalApi:Url"];
        }
        public string GetApiToken()
        {
            return _configuration["ApiToken"];
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Solution.Infrastructure.Data.AppDbContext>(X =>
               X.UseNpgsql(GetConnectionString()));

        }
    }
}
