using Newtonsoft.Json.Linq;

namespace RealStateManager.Utilities
{
  public class GraphQLQuery
  {
    public string OperationName { get; set; }
    public string Query { get; set; }
    public JObject Variables { get; set; }
  }
}
