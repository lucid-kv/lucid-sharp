using System;
using System.Net;
using Lucid.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Lucid
{
    public class Lucid : ILucid
    {
        private readonly LucidOptions _options;

        public Lucid(IOptions<LucidOptions> options)
        {
            _options = options.Value;
        }

        public HttpStatusCode Set(string key, string value)
        {
            var client = new RestClient(BuildKvRequestUri(key));
            var request = new RestRequest(Method.PUT);
            request.AddParameter("text/plain", value, ParameterType.RequestBody);
            return client.Execute(request).StatusCode;
        }

        public string Get(string key)
        {
            var client = new RestClient(BuildKvRequestUri(key));
            var request = new RestRequest(Method.GET);
            return client.Execute(request).Content;
        }

        public HttpStatusCode Drop(string key)
        {
            var client = new RestClient(BuildKvRequestUri(key));
            var request = new RestRequest(Method.DELETE);
            return client.Execute(request).StatusCode;
        }

        private string BuildKvRequestUri(string key)
        {
            return new UriBuilder(_options.Endpoint)
            {
                Path = "/api/kv/" + key
            }.Uri.ToString();
        }
    }
}
