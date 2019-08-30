using System.Collections.Generic;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories.Contracts
{
  public interface IPaymentRepository
  {
    /*
     * READ: Get all the payments relative to a property with a property id
     */
    IEnumerable<Payment> GetAllByPropertyId(string propertyId);

    /*
     * READ: Select how many last payments you want to get
     */
    IEnumerable<Payment> GetAllByPropertyId(string propertyId, int lastPaymentsAmount);
  }
}
