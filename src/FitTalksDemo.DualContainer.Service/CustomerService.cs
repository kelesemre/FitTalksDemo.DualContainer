using FitTalksDemo.DualContainer.Data.Abstactions;
using FitTalksDemo.DualContainer.Entities.Models;
using FitTalksDemo.DualContainer.Service.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Service
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<List<Customer>> GetCustomersAsync()
        {
            var responseList = await _customerRepository.GetAllAsync();
            //_logger.LogInformation("{responseList.Count} records were fetched...",responseList.Count);
            return responseList.ToList();
        }

        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            var response = await _customerRepository.AddAsync(customer);
            _logger.LogInformation($"{customer.Name} was added");
            return response;
        }
    }
}
