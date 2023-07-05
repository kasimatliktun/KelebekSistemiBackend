using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //this, neyi genişletmek istediğiniz anlamına geliyor.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollectiion, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollectiion);
            }
            return ServiceTool.Create(serviceCollectiion);
        }
    }
}