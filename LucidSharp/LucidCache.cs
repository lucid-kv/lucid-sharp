using System;
using System.Threading;
using System.Threading.Tasks;
using EvtSource;
using LucidSharp.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using RestSharp;

namespace LucidSharp
{
    public class LucidCache : IDistributedCache
    {
        private readonly LucidHelper _lucidHelper;

        public LucidCache(LucidHelper lucidHelper)
        {
            _lucidHelper = lucidHelper;
        }
        
        public byte[] Get(string key)
        {
             var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
             var request = new RestRequest(Method.GET);
             return client.Execute(request).RawBytes;
        }

        public async Task<byte[]> GetAsync(string key, CancellationToken token = new CancellationToken())
        {
            var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteGetAsync(request, token);
            return response.RawBytes;
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options = null)
        {
             var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
             var request = new RestRequest(Method.PUT);
             request.AddParameter("text/plain", value, ParameterType.RequestBody);
             client.Execute(request);
        }

        public async Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options,
            CancellationToken token = new CancellationToken())
        {
            
            var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
            var request = new RestRequest(Method.PUT);
            request.AddParameter("text/plain", value, ParameterType.RequestBody);
            await client.ExecuteAsync(request, token);
        }

        public void Refresh(string key)
        {
        }

        public Task RefreshAsync(string key, CancellationToken token = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
             var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
             var request = new RestRequest(Method.DELETE);
             client.Execute(request);
        }

        public async Task RemoveAsync(string key, CancellationToken token = new CancellationToken())
        {
            var client = new RestClient(_lucidHelper.BuildKvRequestUri(key));
            var request = new RestRequest(Method.DELETE);
            await client.ExecuteAsync(request, token);
        }
    }
}