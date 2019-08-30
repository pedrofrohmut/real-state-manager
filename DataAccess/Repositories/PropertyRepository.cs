using System.Collections.Generic;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories
{
  public class PropertyRepository : IPropertyRepository
  {
    private readonly RealStateDbContext context;

    public PropertyRepository(RealStateDbContext context) { this.context = context; }

    public IEnumerable<Property> GetAll() => this.context.Properties;
  }
}
