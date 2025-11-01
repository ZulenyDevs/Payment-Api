using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Payment.Domain.Services;
using Payment.Domain.Payments;

namespace Payment.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IServiceFactory, ServiceFactory>();
            services.AddSingleton<IPaymentFactory, PaymentFactory>();
            // Add other application services here
            return services;
        }

    }
}
