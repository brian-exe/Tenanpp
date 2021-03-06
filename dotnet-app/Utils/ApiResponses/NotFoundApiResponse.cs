using System.Net;

namespace Tenanpp.ApiResponses
{
    public class NotFoundApiResponse : ApiResponse
    {
        public NotFoundApiResponse()
         :base(404, HttpStatusCode.NotFound.ToString())
         {
         }
        
        public NotFoundApiResponse(string message)
            : base(404, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }
}