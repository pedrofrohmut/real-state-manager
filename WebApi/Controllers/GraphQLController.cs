using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using RealStateManager.Utilities;

namespace RealStateManager.WebApi.Controllers
{
  [Route("graphql")]
  [ApiController]
  public class GraphQLController : ControllerBase
  {
    private readonly ISchema schema;
    private readonly IDocumentExecuter documentExecuter;

    public GraphQLController(
        ISchema schema,
        IDocumentExecuter documentExecuter)
    {
      this.schema = schema;
      this.documentExecuter = documentExecuter;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
    {
      if (query == null)
      {
        return BadRequest(new { message = "The Query is null. You must send a query in the resquest method" });
      }
      var inputs = query.Variables?.ToInputs();
      var executionOptions = new ExecutionOptions
      {
        Schema = this.schema,
        Query = query.Query,
        Inputs = inputs
      };
      var result = await this.documentExecuter.ExecuteAsync(executionOptions);
      if (result.Errors?.Count > 0)
      {
        return BadRequest(result);
      }
      return Ok(result);
    }
  }
}
