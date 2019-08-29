using GraphQL.Types;
using RealStateManager.DataAccess.Repositories.Contracts;
using RealStateManager.Types;

namespace RealStateManager.WebApi.Queries
{
  public class PropertyQuery : ObjectGraphType
  {
    public PropertyQuery(IPropertyRepository propertyRepository)
    {
      Field<ListGraphType<PropertyType>>(
        "properties",
        resolve: (context) => propertyRepository.GetAll()
      );
    }
  }
}
