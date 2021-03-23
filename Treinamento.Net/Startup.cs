using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Treinamento.Net.Dominio.Interfaces.Negocio;
using Treinamento.Net.Dominio.Interfaces.Repositorio;
using Treinamento.Net.Negocio;
using Treinamento.Net.Repositorio.Conexao;
using Treinamento.Net.Repositorio.Repositorios;

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

            services.AddSwaggerGen();

            CarregarSwagger(services);

            services.AddRouting(options => options.LowercaseUrls = true); //Deixa as URL's com letras minúsculas

            //Menor trafego de dados
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            // O método AddJsonOptions permite a customização das configurações de serialização
            // Ignorar propriedades nulas
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Curso");
                c.RoutePrefix = "api/swagger";
            });

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
            services.AddScoped<IConexaoSqlServer, ConexaoSqlServer>();

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            #endregion Repositorio
        }

        private void CarregarSwagger(IServiceCollection services)
        {
            //Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Api Core - Curso",
                        Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                        Description = "Treinamento .NET",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Curso",
                            Email = string.Empty,
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "Copyright - Curso, todos os direitos reservados.",
                        }
                    });

                string caminhoAplicacao = 
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = 
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = 
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);

            });
        }
    }
}
