using System.Net;

namespace Tenanpp.ApiResponses
{
    public class BadRequestApiResponse : ApiResponse
    {
        public BadRequestApiResponse()
         :base(400, HttpStatusCode.BadRequest.ToString())
         {
         }
        
        public BadRequestApiResponse(string message)
            : base(400, HttpStatusCode.BadRequest.ToString(), message)
        {
        }
    }
}