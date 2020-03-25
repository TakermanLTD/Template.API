using Microsoft.AspNetCore.Mvc;
using Template.API.Services.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Template.API.API.Controllers
{
    [SwaggerTag("Example")]
    [Produces("application/json")]
    public class ExamplesController : Controller
    {
        private IExampleService _exampleService;

        public ExamplesController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet("Get", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var examples = await _exampleService.GetAll();

            return Ok(examples);
        }
    }
}