using FitTalksDemo.DualContainer.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Service.Abstractions
{
    public interface ICustomerService
    {
        public Task<Customer> SaveCustomerAsync(Customer customer);
        public Task<List<Customer>> GetCustomersAsync();
    }
}
