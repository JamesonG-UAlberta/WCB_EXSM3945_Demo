using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // Standard logging stuff, don't need to edit these.
        private readonly ILogger<SampleController> _logger;
        // More logging stuff used with the constructor.
        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        // GET means we're GETting information. (Read)
        [HttpGet]
        // By returning an action result, that allows us to return things (within spec) other than the specified type. This includes other response codes such as Forbidden, Not Found, etc.
        public ActionResult<string> Get(string exampleParam)
        {
            switch (exampleParam.Trim())
            {
                case "404":
                    // Code 404 is Not Found, which is typically used for (in API context) for if the user requests a record by ID and that ID does not exist.
                    return NotFound();
                    break;
                case "Coffee":
                    // If a desired status code does not have a DotNET method implementation, it can be sent forcefully with StatusCode().
                    return StatusCode(418);
                    break;
                case "400":
                    // Bad requests are when the user gives you invalid data (IE giving you "potato" instead of "4"). This does not mean something that's valid but not found (IE ID 100 when there are 50 records).
                    return BadRequest();
                    break;
                default:
                    // If you return the proper type and don't specify another status code, it defaults to 200 (OK), with your response.
                    return "You sent a GET request! - " + exampleParam;
                    break;
            }
        }

        // POST is a submission of a form (typically).
        [HttpPost]
        public string Post()
        {
            return "You sent a POST request!";
        }

        // PUT is for PUTting new information in a store. (Write)
        [HttpPut]
        public string Put()
        {
            return "You sent a PUT request!";
        }

        // PATCH is for PATCHing information to a new version. (Update)
        [HttpPatch]
        public string Patch()
        {
            return "You sent a PATCH request!";
        }

        // DELETE is for DELET(E)ing information. (Delete)
        // Note that the DELETE method CAN be used for archival (discontinuation, etc).
        [HttpDelete]
        public string Delete()
        {
            return "You sent a DELETE request!";
        }

        // OPTIONS is typically used to send available options back to the user.
        [HttpOptions]
        public string Options()
        {
            return "You sent an OPTIONS request!";
        }

        // HEAD returns what the headers of a GET request response would have been, sent to the same endpoint.
        [HttpHead]
        public string Head()
        {
            return "You sent a HEAD request!";
        }

    }
}
