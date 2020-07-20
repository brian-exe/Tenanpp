using Microsoft.AspNetCore.Mvc;
using Tenanpp.ApiResponses;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Diagnostics;

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
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            /*Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);*/
                
            return new ObjectResult(error);
        }
    }
}