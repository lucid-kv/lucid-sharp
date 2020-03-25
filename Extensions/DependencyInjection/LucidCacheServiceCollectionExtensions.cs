using System;
using Lucid.Helpers;
using Lucid.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Lucid.Extensions.DependencyInjection
{
    public static class LucidCacheServiceCollectionExtensions
    {
        /// <summary>
        /// Implement Lucid for Cache
        /// </summary>
        public static IServiceCollection AddLucidCache(this IServiceCollection services, Action<LucidCacheOptions> setupAction)
        {
            // if (services == null)
            // {
            //     throw new ArgumentNullException(nameof(services));
            // }
            //
            // if (setupAction == null)
            // {
            //     throw new ArgumentNullException(nameof(setupAction));
            // }

            services.AddOptions();
            services.Configure(setupAction);
            services.AddTransient<LucidHelper>();
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, LucidCache>());

            return services;
        }
    }
}