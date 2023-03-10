using System.Net;

namespace RSSManagmentService.Api.Dto.Model
{
    public class WebServiceError
    {
        public HttpStatusCode Status { get; set; }

        public string Error { get; set; }

        public WebServiceError(HttpStatusCode status, string error)
        {
            Status = status;
            Error = error;
        }
    }
}
