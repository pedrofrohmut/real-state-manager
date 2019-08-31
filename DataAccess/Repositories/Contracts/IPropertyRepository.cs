using System.Collections.Generic;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories.Contracts
{
  public interface IPropertyRepository
  {
    /*
     * QUERY: Get All payments
     */
    IEnumerable<Property> GetAll();

    /*
     * QUERY: Get a property for the passed id
     */
    Property GetById(string id);

    /*
     * MUTATION: Add a new property and returns it
     */
    Property Add(Property newProperty);
  }
}
