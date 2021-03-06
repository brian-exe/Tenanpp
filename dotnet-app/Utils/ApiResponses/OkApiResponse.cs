using System.Net;

namespace Tenanpp.ApiResponses
{
    public class OkApiResponse : ApiResponse
    {
        public OkApiResponse(object data)
         :base(200, HttpStatusCode.OK.ToString())
         {
             Data = data;
         }
        
        public OkApiResponse(object data, string message)
            : base(200, HttpStatusCode.OK.ToString(), HttpStatusCode.OK.ToString())
        {
            Data = data;
        }
    }
}