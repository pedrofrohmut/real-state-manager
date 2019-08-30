using GraphQL.Types;
using RealStateManager.DataBase.Models;

namespace RealStateManager.Types
{
  public class PaymentType : ObjectGraphType<Payment>
  {
    public PaymentType()
    {
      Field(x => x.Id);
      Field(x => x.Value);
      Field(x => x.CreatedAt);
      Field(x => x.DateOverdue);
      Field(x => x.IsPaid);
    }
  }
}
