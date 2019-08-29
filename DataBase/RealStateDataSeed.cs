using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataBase
{
  public static class RealStateDataSeed
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var requiredService = serviceProvider.GetRequiredService<DbContextOptions<RealStateDbContext>>();

      using (var context  = new RealStateDbContext(requiredService)) 
      {
        if (context.Properties.Any()) return;
        context.AddRange(properties);
        context.SaveChanges();
      }
    }

    private static IEnumerable<Property> properties = new List<Property>
    {
      new Property
      {
        City = "Katowice",
        Family = "Smith",
        Name = "Big house",
        Street = "Sokolska",
        Value = 100000,
        Payments = new List<Payment>
        {
          new Payment
          {
            CreatedAt = new DateTime(2019, 07, 01),
            DateOverdue = new DateTime(2019, 07, 15),
            IsPaid = true,
            Value = 1500
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 08, 01),
            DateOverdue = new DateTime(2019, 08, 15),
            IsPaid = true,
            Value = 1500
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 09, 01),
            DateOverdue = new DateTime(2019, 09, 15),
            IsPaid = false,
            Value = 1500
          }
        }
      },
      new Property
      {
        City = "Warszawa",
        Family = "Nowak",
        Name = "White house",
        Street = "Wiejska",
        Value = 300500,
        Payments = new List<Payment>
        {
          new Payment
          {
            CreatedAt = new DateTime(2019, 07, 01),
            DateOverdue = new DateTime(2019, 07, 15),
            IsPaid = true,
            Value = 3000
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 08, 01),
            DateOverdue = new DateTime(2019, 08, 15),
            IsPaid = true,
            Value = 3000
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 09, 01),
            DateOverdue = new DateTime(2019, 09, 15),
            IsPaid = false,
            Value = 3000
          }
        }
      },
      new Property
      {
        City = "Gdańska",
        Family = "Pomorscy",
        Name = "Sea house",
        Street = "Gdańska",
        Value = 51000,
        Payments = new List<Payment>
        {
          new Payment
          {
            CreatedAt = new DateTime(2019, 07, 01),
            DateOverdue = new DateTime(2019, 07, 15),
            IsPaid = true,
            Value = 800
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 08, 01),
            DateOverdue = new DateTime(2019, 08, 15),
            IsPaid = true,
            Value = 800
          },
          new Payment
          {
            CreatedAt = new DateTime(2019, 09, 01),
            DateOverdue = new DateTime(2019, 09, 15),
            IsPaid = true,
            Value = 800
          }
        }
      }
    };
  }
}
