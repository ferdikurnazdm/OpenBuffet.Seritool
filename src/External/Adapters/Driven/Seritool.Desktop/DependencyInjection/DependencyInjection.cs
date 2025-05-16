using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seritool.Application.Engine;
using Seritool.Application.Ports;
using Seritool.Seriport;

namespace Seritool.Desktop.DependencyInjection {
    /// <summary>
    /// this class manage the services
    /// </summary>
    public static class DependencyInjection {
        /// <summary>
        /// this field keeps the service provider
        /// </summary>
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// this constructor sets the services
        /// </summary>
        static DependencyInjection() {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ISeriport, SeriportAdapter>()
                .AddSingleton<SeritoolEngine>()
                .BuildServiceProvider();
        }

        /// <summary>
        /// this property return the service provider
        /// </summary>
        public static IServiceProvider GetServiceProvider {
            get { return _serviceProvider; }
        }
    }
}
