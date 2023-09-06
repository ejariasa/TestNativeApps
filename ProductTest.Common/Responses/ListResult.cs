using System.Collections.Generic;
using System.Net;

namespace ProductTest.Common.Responses
{
    public class ListResult<T>
    {
        public List<T> DataList { get; set; }
        public bool Success { get; set; }
        public int Count { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ResponseReason { get; set; }
    }
}
