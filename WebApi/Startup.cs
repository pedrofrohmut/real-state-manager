using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealStateManager.DataAccess.Repositories;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase;
using RealStateManager.Types;
using RealStateManager.WebApi.Queries;
using RealStateManager.WebApi.Schema;

namespace WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration) { Configuration = configuration; }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddEntityFrameworkNpgsql()
        .AddDbContext<RealStateDbContext>(options =>
            options.UseNpgsql(Configuration["ConnectionStrings:PostgreSQL:RealStateManagerDb"]));
      services.AddSingleton<IConfiguration>(this.Configuration);
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<PropertyQuery>();
      services.AddSingleton<PropertyType>();
      services.AddTransient<IPropertyRepository, PropertyRepository>();
      var serviceProvider = services.BuildServiceProvider();
      services.AddSingleton<ISchema>(
          new RealStateSchema(
            new FuncDependencyResolver(type => serviceProvider.GetService(type))));
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      app.UseGraphiQl();
      app.UseMvc();
    }
  }
}
