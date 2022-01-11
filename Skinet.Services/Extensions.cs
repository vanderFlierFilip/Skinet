using Microsoft.Extensions.DependencyInjection;
using Skinet.Core.Interfaces;
using Skinet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.Scan(b => b.FromAssemblies(assembly)
                .AddClasses(x => x.AssignableTo(typeof(IGenericRepository<>)))
                .AsImplementedInterfaces().WithScopedLifetime());
            
            return services;
        }
    }
}
