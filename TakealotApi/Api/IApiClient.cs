using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakealotApi.Api
{
    public interface IApiClient
    {
        ApiResult<T> GET<T>(string apiEndPoint, params Parameter[] parameters) where T : new();

        ApiResult<T> POST<T>(string apiEndPoint, object objectToUpdate) where T : new();

        ApiResult<T> PUT<T>(string apiEndPoint, object objectToUpdate) where T : new();

        ApiResult<T> DELETE<T>(string apiEndPoint, object objectToUpdate) where T : new();
    }
}
