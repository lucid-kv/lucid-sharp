using System;
using Lucid.Options;
using Microsoft.Extensions.Options;

namespace Lucid.Helpers
{
    public class LucidHelper
    {
        private readonly LucidCacheOptions _options;

        public LucidHelper(IOptions<LucidCacheOptions> options)
        {
            _options = options.Value;
        }
        
        public string BuildKvRequestUri(string key)
        {
            return new UriBuilder(_options.Configuration)
            {
                Path = "/api/kv/" + key
            }.Uri.ToString();
        }
    }
}