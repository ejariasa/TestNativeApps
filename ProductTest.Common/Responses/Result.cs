using System.Net;

namespace ProductTest.Common.Responses
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ResponseReason { get; set; }

    }
}
