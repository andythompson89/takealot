using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TakealotApi.Api
{
    public class ApiClient : IApiClient
    {
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public ApiResult<T> GET<T>(string apiEndPoint, params Parameter[] parameters) where T : new()
        {
            var request = new RestRequest(apiEndPoint, Method.GET);
            request.Parameters.AddRange(parameters);

            var response = Execute<T>(request);
            return response;
        }

        public ApiResult<T> POST<T>(string apiEndPoint, object objectToUpdate) where T : new()
        {
            var request = new RestRequest(apiEndPoint, Method.POST);

            if (objectToUpdate != null)
            {
                request.AddObject(objectToUpdate);
            }

            var response = Execute<T>(request);
            return response;
        }

        public ApiResult<T> PUT<T>(string apiEndPoint, object objectToUpdate) where T : new()
        {
            var request = new RestRequest(apiEndPoint, Method.PUT);

            if (objectToUpdate != null)
            {
                request.AddObject(objectToUpdate);
            }

            var response = Execute<T>(request);
            return response;
        }

        public ApiResult<T> DELETE<T>(string apiEndPoint, object objectToUpdate) where T : new()
        {
            var request = new RestRequest(apiEndPoint, Method.DELETE);

            if (objectToUpdate != null)
            {
                request.AddObject(objectToUpdate);
            }

            var response = Execute<T>(request);
            return response;
        }

        private ApiResult<T> Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(_baseUrl);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                return new ApiResult<T>(HttpStatusCode.InternalServerError, response.ErrorException);
            }

            return new ApiResult<T>(response.StatusCode, response.Data);
        }
    }
}
