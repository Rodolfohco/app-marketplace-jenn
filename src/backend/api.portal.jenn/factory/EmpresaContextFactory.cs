using api.portal.jenn.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace api.portal.jenn.factory
{
    public class EmpresaContextFactory : IDesignTimeDbContextFactory<DBJennContext>
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public EmpresaContextFactory(IHostEnvironment _environment, IConfiguration _config)
        {
            this.environment = _environment;
            this.config = _config;
        }
        public DBJennContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DBJennContext>();
            var connectionString = string.Empty;

            if (config.GetValue<string>("BancoPrincipal") == "SQLServer")
            {
                connectionString = config.GetValue<string>("DataBase:SQLConnection");
                builder.UseSqlServer(connectionString);
            }
            else if(config.GetValue<string>("BancoPrincipal") == "MySQL")
            {
                connectionString = config.GetValue<string>("DataBase:MySqlConnection");
                builder.UseMySql(connectionString);
            }
            return new DBJennContext(builder.Options);
        }
    }
}
