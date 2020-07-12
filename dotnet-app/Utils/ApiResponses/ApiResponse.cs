using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
namespace Tenanpp.ApiResponses
{
    public class ApiResponse
    {
        public int StatusCode { get; private set; }
        public string StatusDescription { get; private set; }
        public object Data {get; set; }
        public string Message { get; private set; } = "";

        public ApiResponse(int statusCode, string statusDescription)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Data = new object();
        }

        public ApiResponse(int statusCode, string statusDescription, string message)
            : this(statusCode, statusDescription)
        {
            this.Message = message;
        }
    }
}