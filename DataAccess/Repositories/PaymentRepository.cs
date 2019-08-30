using System.Collections.Generic;
using System.Linq;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataAccess.Repositories
{
  public class PaymentRepository : IPaymentRepository
  {
    private readonly RealStateDbContext context;

    public PaymentRepository(RealStateDbContext context) { this.context = context; }

    public IEnumerable<Payment> GetAllByPropertyId(string propertyId) =>
      this.context.Payments
        .Where(payment => payment.PropertyId == propertyId);

    public IEnumerable<Payment> GetAllByPropertyId(string propertyId, int lastPaymentsAmount) =>
      this.context.Payments
        .Where(payment => payment.PropertyId == propertyId)
        .OrderByDescending(payment => payment.CreatedAt)
        .Take(lastPaymentsAmount);
  }
}
