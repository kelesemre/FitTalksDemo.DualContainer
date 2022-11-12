using FitTalksDemo.DualContainer.Entities.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Data.Contexts
{
    public class CustomerDbContextSeed
    {
        /// <summary>
        /// Seed Db app runs in case db is empty
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static async Task SeedAsync(CustomerDbContext dbContext, ILogger<CustomerDbContextSeed> logger)
        {
            if (!dbContext.Customers.Any()) // check any product in the db
            {
                dbContext.Customers.AddRange(InsertCustomerList());
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CustomerDbContext).Name);
            }
        }

        public static object SeedAsync(CustomerDbContext context, object logger)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// InsertProductTypes when initialize db
        /// </summary>
        /// <returns></returns>

        private static IEnumerable<Customer> InsertCustomerList()
        {
            return new List<Customer>
            {
                new Customer(){  Name = "Ali", Surname = "Alioglu", Email = "develoer.emrekeles@gmail.com"},
                new Customer(){  Name = "Bilal", Surname = "Bilaloglu", Email = "alia@gmail.com"},
                new Customer(){  Name = "Cengiz", Surname = "Cengizoglu", Email = "alia@gmail.com"},
                new Customer(){  Name = "Deniz", Surname = "Denizoglu", Email = "alia@gmail.com"},
                new Customer(){  Name = "Emre", Surname = "Emreoglu", Email = "alia@gmail.com"},
                new Customer(){  Name = "Fatih", Surname = "Fatihoglu", Email = "alia@gmail.com"},
                new Customer(){  Name = "Geylani", Surname = "Geylanioglu", Email = "alia@gmail.com"}
            };
        }
    }
}
