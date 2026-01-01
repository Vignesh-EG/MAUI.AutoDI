using MAUI.AutoDI.Attributes;
using MAUI.AutoDI.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MAUI.AutoDI.Extensions
{
    public static class ServiceCollectionAutoRegister
    {
        public static IServiceCollection AutoRegisterFromAssembly(
            this IServiceCollection services,
            Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    !t.IsDefined(typeof(IgnoreAutoRegisterAttribute), inherit: true) &&
                    (t.Name.EndsWith("Page") ||
                     t.Name.EndsWith("ViewModel") ||
                     t.Name.EndsWith("Service")))
                .ToList();

            foreach (var type in types)
            {
                var lifetime = type
                    .GetCustomAttribute<ServiceLifetimeAttribute>()
                    ?.Lifetime ?? ServiceLifetimeType.Singleton;

                Register(services, type, lifetime);
            }

            return services;
        }

        private static void Register(
            IServiceCollection services,
            Type implementation,
            ServiceLifetimeType lifetime)
        {
            var serviceInterface = implementation
                .GetInterfaces()
                .FirstOrDefault(i =>
                    i.Name == $"I{implementation.Name}");

            switch (lifetime)
            {
                case ServiceLifetimeType.Transient:
                    if (serviceInterface != null)
                        services.AddTransient(serviceInterface, implementation);
                    else
                        services.AddTransient(implementation);
                    break;

                case ServiceLifetimeType.Scoped:
                    if (serviceInterface != null)
                        services.AddScoped(serviceInterface, implementation);
                    else
                        services.AddScoped(implementation);
                    break;

                default: // Singleton
                    if (serviceInterface != null)
                        services.AddSingleton(serviceInterface, implementation);
                    else
                        services.AddSingleton(implementation);
                    break;
            }
        }
    }
}
