using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Treinamento.Net.Dominio.Interfaces.Negocio;
using Treinamento.Net.Negocio;

namespace Treinamento.Net
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
            InjecaoDeDependencia(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InjecaoDeDependencia(IServiceCollection services)
        {
            #region Negocio
            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            #endregion Negocio

            #region Repositorio
            //services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            #endregion Repositorio
        }

        private void CarregarSwagger(IServiceCollection services)
        {
            //Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(char =>
            {
                c.
            });
        }
    }
}
