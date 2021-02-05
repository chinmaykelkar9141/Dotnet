using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using postman_demo.Services;
using postman_demo.ViewModels;

namespace postman_demo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet("[Controller]/[Action]")]
        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }
        
        
        [HttpGet("[Controller]/[Action]")]
        public async Task<CustomerViewModel> GetCustomerByCustomerId([FromQuery] string customerId)
        {
            return await _customerService.GetCustomerByCustomerId(customerId);
        }
        
        [HttpGet("[Controller]/[Action]")]
        public async Task<List<CustomerViewModel>> GetCustomerByCustomerIds([FromQuery] List<string> customerIds)
        {
            return await _customerService.GetCustomerByCustomerIds(customerIds);
        }

        [HttpPost("[Controller]/[Action]")]
        public async Task<List<CustomerViewModel>> AddCustomer([FromBody] CustomerViewModel customerViewModel)
        {
            return await _customerService.AddCustomer(customerViewModel);
        }

        [HttpPut("[Controller]/[Action]")]
        public async Task<List<CustomerViewModel>> UpdateCustomer([FromBody] CustomerViewModel customerViewModel)
        {
            return await _customerService.UpdateCustomer(customerViewModel);
        }
        
        [HttpDelete("[Controller]/[Action]")]
        public async Task<List<CustomerViewModel>> DeleteCustomer([FromQuery] string customerId)
        {
            return await _customerService.DeleteCustomer(customerId);
        }
        
    }
}