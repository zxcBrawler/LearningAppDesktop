using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Utils
{
    public static class ServiceLocator
    {
        private static IServiceProvider? ServiceProvider { get; set; }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static T? GetService<T>() where T : class
        {
            return ServiceProvider?.GetService<T>();
        }
    }
}
