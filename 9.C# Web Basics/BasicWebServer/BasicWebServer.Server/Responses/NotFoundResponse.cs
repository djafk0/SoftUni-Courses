using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }
    }
}
