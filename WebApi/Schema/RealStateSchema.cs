using GraphQL;
using RealStateManager.WebApi.Queries;

namespace RealStateManager.WebApi.Schema
{
  public class RealStateSchema : GraphQL.Types.Schema
  {
    public RealStateSchema(IDependencyResolver resolver) : base(resolver)
    {
      Query = resolver.Resolve<PropertyQuery>();
    }
  }
}
