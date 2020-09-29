
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teste_WebMotors.Application.Services;
using Teste_WebMotors.Core.Interfaces.Repository;
using Teste_WebMotors.Core.Interfaces.Services;
using Teste_WebMotors.Infrastructure;
using Teste_WebMotors.Infrastructure.Persistence.CrossCutting;
using Teste_WebMotors.Infrastructure.Persistence.Repositories;

namespace Teste_WebMotors.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddScoped<IAnuncioRepository,AnuncioRepository>();           
            services.AddScoped<IAnuncioServices, AnuncioServices>();
            services.AddScoped<IMakeCrossCutting, MakeCrossCutting>();
            services.AddScoped<IModelCrossCutting, ModelCrossCutting>();
            services.AddScoped<IVersionCrossCutting, VersionCrossCutting>();

            Context.ConnectionString = Configuration.GetConnectionString("ConnectionString");

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
