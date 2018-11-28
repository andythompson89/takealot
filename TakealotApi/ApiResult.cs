using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TakealotApi
{
    public class ApiResult<T>
    {
        public ApiResult(HttpStatusCode httpStatusCode, T data, string requestUrl)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
            RequestUrl = requestUrl;
        }

        public ApiResult(HttpStatusCode httpStatusCode, Exception exception, string requestUrl)
        {
            HttpStatusCode = httpStatusCode;
            Exception = exception;
            RequestUrl = requestUrl;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string RequestUrl { get; set; }

        public T Data { get; set; }

        public Exception Exception { get; set; }
    }
}
