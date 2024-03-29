
using Arsenal.Domain.Cliente;
using Arsenal.Domain.Contracts.Domain.Cliente;
using Arsenal.Domain.Contracts.Infrastructure.Repository;
using Arsenal.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Arsenal.Application
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
      services.AddControllers();

      services.AddScoped<IClienteService, ClienteService>();
      services.AddScoped<IClienteRepository, ClienteRepository>();

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1",
        new OpenApiInfo
        {
          Title = "Negativar cliente",
          Version = "v1",
          Description = "DDD Localiza"
        });
      });
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

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello World com a Localiza");
      });
    }
  }
}
