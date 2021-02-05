using System.Collections.Generic;
using System.Threading.Tasks;
using postman_demo.ViewModels;

namespace postman_demo.Services
{

        public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerViewModel> GetCustomerByCustomerId(string cid);
        Task<List<CustomerViewModel>> AddCustomer(CustomerViewModel customerViewModel);
        Task<List<CustomerViewModel>> UpdateCustomer(CustomerViewModel customerViewModel);
        Task<List<CustomerViewModel>> DeleteCustomer(string customerId);
        Task<List<CustomerViewModel>> GetCustomerByCustomerIds(List<string> customerIds);
    }
        
}