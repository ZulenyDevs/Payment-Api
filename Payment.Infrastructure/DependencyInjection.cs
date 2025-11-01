using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Payment.Domain.Abstractions;
using Payment.Infrastructure.DomainModel;
using Payment.Infrastructure.Repositories;
using Payment.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Payment.Domain.Payments;
using Payment.Application;
using Payment.Domain.Services;


namespace Payment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, string serviceName)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseNpgsql(connectionString));
            services.AddDbContext<DomainDbContext>(context =>
                    context.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IPaymentRepository, PaymentRepository>()
                    .AddScoped<IServiceRepository, ServiceRepository>();

            services.AddAplication();

            return services;
        }
    }
}
