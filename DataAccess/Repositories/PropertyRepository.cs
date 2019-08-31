using System.Collections.Generic;
using System.Linq;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories
{
  public class PropertyRepository : IPropertyRepository
  {
    private readonly RealStateDbContext context;

    public PropertyRepository(RealStateDbContext context) { this.context = context; }

    public Property Add(Property newProperty)
    {
      this.context.Properties.Add(newProperty);
      this.context.SaveChanges();
      // now with Id, added by EFCore when saved to db
      return newProperty;
    }

    public IEnumerable<Property> GetAll() => this.context.Properties;

    public Property GetById(string id) => this.context.Properties.FirstOrDefault(property => property.Id == id);
  }
}
