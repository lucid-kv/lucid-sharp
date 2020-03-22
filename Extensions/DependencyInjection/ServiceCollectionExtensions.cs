using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lucid.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLucid(this IServiceCollection services, Action<LucidOptions> options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            services.Configure(options);

            services.AddTransient<ILucid, Lucid>();
            return services;
        }
    }
}