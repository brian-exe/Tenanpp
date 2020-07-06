using System.Net;

namespace Tenanpp.ApiResponse
{
    public class OkApiResponse : ApiResponse
    {
        public object Data {get;}
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