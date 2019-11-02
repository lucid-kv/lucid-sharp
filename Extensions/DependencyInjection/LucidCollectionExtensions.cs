using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lucid.Extensions.DependencyInjection
{
    public static class LucidCollectionExtensions
    {
        public static IServiceCollection AddLucid(this IServiceCollection services, Action<LucidOptions> lucidOptions)
        {
            services.AddTransient<ILucid>();
            return services;
        }
    }
}