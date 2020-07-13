using System.Net;

namespace Tenanpp.ApiResponses
{
    public class BadRequestApiResponse : ApiResponse
    {
        public BadRequestApiResponse()
         :base(404, HttpStatusCode.BadRequest.ToString())
         {
         }
        
        public BadRequestApiResponse(string message)
            : base(404, HttpStatusCode.BadRequest.ToString(), message)
        {
        }
    }
}