using GraphQL.Types;

namespace RealStateManager.Types
{
  public class PropertyInputType : InputObjectGraphType
  {
    public PropertyInputType()
    {
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<StringGraphType>("city");
      Field<StringGraphType>("family");
      Field<StringGraphType>("street");
      Field<IntGraphType>("value");
    }
  }
}
