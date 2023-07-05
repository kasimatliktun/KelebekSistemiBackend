using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();


        }
    }
}