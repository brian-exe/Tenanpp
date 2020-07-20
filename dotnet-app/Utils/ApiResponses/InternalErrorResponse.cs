using System.Net;

namespace Tenanpp.ApiResponses
{
    public class InternalErrorResponse : ApiResponse
    {
        public InternalErrorResponse()
         :base(500, HttpStatusCode.InternalServerError.ToString())
         {
         }
        
        public InternalErrorResponse(string message)
            : base(500, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }
}