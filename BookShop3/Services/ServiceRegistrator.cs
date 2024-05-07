using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop3.Services.Interfaces;
using MathCore.WPF.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop3.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<ISalesService ,SalesService>()
        ;

    }
}
