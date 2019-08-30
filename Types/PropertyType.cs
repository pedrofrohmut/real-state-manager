using GraphQL.Types;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase.Models;

namespace RealStateManager.Types
{
  public class PropertyType : ObjectGraphType<Property>
  {
    public PropertyType(IPaymentRepository paymentRepository)
    {
      Field(property => property.Id);
      Field(property => property.Name);
      Field(property => property.Value);
      Field(property => property.City);
      Field(property => property.Family);
      Field(property => property.Street);

      Field<ListGraphType<PaymentType>>(
        "payments",
        arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
        resolve: context => {
          var lastItemFilter = context.GetArgument<int?>("last");
          return lastItemFilter != null
            ? paymentRepository.GetAllByPropertyId(context.Source.Id, lastItemFilter.Value)
            : paymentRepository.GetAllByPropertyId(context.Source.Id);
        }
      );
    }
  }
}
