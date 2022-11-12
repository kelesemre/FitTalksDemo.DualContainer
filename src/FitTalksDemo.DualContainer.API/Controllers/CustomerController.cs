using FitTalksDemo.DualContainer.Common.Response;
using FitTalksDemo.DualContainer.Entities.Models;
using FitTalksDemo.DualContainer.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : GenericControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("[action]", Name = "GetCustomersAsync")]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var response = await _customerService.GetCustomersAsync();
            return CreateActionResultInstance(GenericResponse<List<Customer>>.Success(response));
        }

        [HttpPost]
        [Route("[action]", Name = "SaveCustomerAsync")]
        public async Task<IActionResult> SaveCustomerAsync([FromBody] Customer customer)
        {
            var response = await _customerService.SaveCustomerAsync(customer);
            return CreateActionResultInstance(GenericResponse<Customer>.Success(response));
        }

    }
}
