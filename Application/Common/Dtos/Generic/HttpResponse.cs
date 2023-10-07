using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos.Generic
{
    public class HttpResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }

        public HttpResponse(HttpStatusCode statusCode, string message, T content)
        {
            StatusCode = statusCode;
            Message = message;
            Content = content;
        }
    }
}
