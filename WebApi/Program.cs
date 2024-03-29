﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealStateManager.DataBase;

namespace WebApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateWebHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;

        try 
        {
          var context = services.GetRequiredService<RealStateDbContext>();
          context.Database.Migrate();
          RealStateDataSeed.Initialize(services);
        } 
        catch (Exception ex) 
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, " ### An Error occured seeding the database ### ");
        }
      }
      
      host.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
       .UseStartup<Startup>();
  }
}
