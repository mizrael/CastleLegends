using System;

namespace CastleLegends.Editor.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider provider) where TService : class
        {
            return provider.GetService(typeof(TService)) as TService;
        }
    }
}
