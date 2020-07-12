using api.portal.jenn.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace api.portal.jenn.factory
{
    public class EmpresaContextFactory : IDesignTimeDbContextFactory<CustomContext>
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public EmpresaContextFactory(IHostEnvironment _environment, IConfiguration _config)
        {
            this.environment = _environment;
            this.config = _config;
        }
        public CustomContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomContext>();
            var connectionString = config.GetValue<string>("DataBase:MySqlConnection");

            builder.UseMySql(connectionString);

            return new CustomContext(builder.Options);
        }
    }
}
