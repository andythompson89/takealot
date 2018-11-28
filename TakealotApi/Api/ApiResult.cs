using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TakealotApi.Api
{
    public class ApiResult<T>
    {
        public ApiResult(HttpStatusCode httpStatusCode, T data)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
        }

        public ApiResult(HttpStatusCode httpStatusCode, Exception exception)
        {
            HttpStatusCode = httpStatusCode;
            Exception = exception;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public T Data { get; set; }

        public Exception Exception { get; set; }
    }
}
