using FitTalksDemo.DualContainer.Data.Abstactions;
using FitTalksDemo.DualContainer.Data.Contexts;
using FitTalksDemo.DualContainer.Data.Repositories;
using FitTalksDemo.DualContainer.Service.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("CustomerConnectionString"), options => options.EnableRetryOnFailure()));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
