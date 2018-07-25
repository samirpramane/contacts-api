using System.Net;

namespace ContactsManager.Web.Models
{
    public class ApiHttpResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Response { get; set; }
    }
}