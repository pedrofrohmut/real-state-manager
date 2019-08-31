using GraphQL.Types;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.DataBase.Models;
using RealStateManager.Types;

namespace RealStateManager.WebApi.Mutations
{
  public class PropertyMutation : ObjectGraphType
  {
    public PropertyMutation(IPropertyRepository propertyRepository)
    {
      Field<PropertyType>
      (
        "addProperty",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "newProperty" }
        ),
        resolve: (context) => {
          var property = context.GetArgument<Property>("newProperty");
          return propertyRepository.Add(property);
        }
      );
    }
  }
}
