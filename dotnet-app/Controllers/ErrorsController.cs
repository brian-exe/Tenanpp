using Microsoft.AspNetCore.Mvc;
using Tenanpp.ApiResponses;
using System.Net;

namespace Tenanpp.Controllers
{
    [Route("/error")]
    [ApiController]
    public class ErrorsController : Controller
    {
        [Route("{code}")]
        public IActionResult Error(int code)
        {
            HttpStatusCode parsedCode = (HttpStatusCode)code;
            ApiResponse error = new ApiResponse(code, parsedCode.ToString());

            return new ObjectResult(error);
        }
    }
}