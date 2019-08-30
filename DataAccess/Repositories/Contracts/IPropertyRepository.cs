using System.Collections.Generic;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories.Contracts
{
  public interface IPropertyRepository
  {
    /*
     * READ: Get All payments
     */
    IEnumerable<Property> GetAll();
  }
}
