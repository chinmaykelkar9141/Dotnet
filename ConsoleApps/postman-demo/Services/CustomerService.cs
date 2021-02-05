using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using postman_demo.Models;
using postman_demo.ViewModels;


namespace postman_demo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RetailBusinessManagementContext _retailBusinessManagementContext;

        public CustomerService(RetailBusinessManagementContext retailBusinessManagementContext)
        {
            _retailBusinessManagementContext = retailBusinessManagementContext;
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            
            
            
            var customerDto = _retailBusinessManagementContext.Customers;
            var customers = await customerDto.Select(x => new CustomerViewModel
            {
                Cid = x.Cid,
                Name = x.Name,
                VisitsMade = x.VisitsMade,
                LastVisitDate = x.LastVisitDate,
                Telephone = x.Telephone,
            }).ToListAsync();

            return customers;
        }

        public async Task<CustomerViewModel> GetCustomerByCustomerId(string cid)
        {
            return await _retailBusinessManagementContext.Customers.Where(x => x.Cid == cid).Select(x =>
                new CustomerViewModel
                {
                    Cid = x.Cid,
                    Name = x.Name,
                    VisitsMade = x.VisitsMade,
                    LastVisitDate = x.LastVisitDate,
                    Telephone = x.Telephone

                }).FirstOrDefaultAsync();
        }

        public async Task<List<CustomerViewModel>> AddCustomer(CustomerViewModel customerViewModel)
        {
            
            var customerDataModel = new Customers
            {
                Cid = customerViewModel.Cid,
                Name = customerViewModel.Name,
                VisitsMade = customerViewModel.VisitsMade,
                Telephone = customerViewModel.Telephone,
                LastVisitDate = customerViewModel.LastVisitDate

            };
            var customer = _retailBusinessManagementContext.Customers;

            if (await customer.AnyAsync(x => x.Cid == customerViewModel.Cid))
            {
                throw new Exception($"{customerDataModel.Cid} is already present in the system");
            }
            await customer.AddAsync(customerDataModel);
            await _retailBusinessManagementContext.SaveChangesAsync();

            return await GetAllCustomers();
        }

        public async Task<List<CustomerViewModel>> UpdateCustomer(CustomerViewModel customerViewModel)
        {
            var customerDataModel = new Customers
            {
                Cid = customerViewModel.Cid,
                Name = customerViewModel.Name,
                VisitsMade = customerViewModel.VisitsMade,
                Telephone = customerViewModel.Telephone,
                LastVisitDate = customerViewModel.LastVisitDate

            };
            var customer = _retailBusinessManagementContext.Customers;
            customer.Update(customerDataModel);
            await _retailBusinessManagementContext.SaveChangesAsync();
            return await GetAllCustomers();

        }

        public async Task<List<CustomerViewModel>> DeleteCustomer(string customerId)
        {
            var purchases = _retailBusinessManagementContext.Purchases;
            var customer = _retailBusinessManagementContext.Customers;
            var customerDatamodel = new Customers {Cid = customerId};
            purchases.RemoveRange(purchases.Where(p => p.Cid == customerId));
            customer.Remove(customerDatamodel);
            await _retailBusinessManagementContext.SaveChangesAsync();
            return await GetAllCustomers();
        }

        public async Task<List<CustomerViewModel>> GetCustomerByCustomerIds(List<string> customerIds)
        {
            return await _retailBusinessManagementContext.Customers
                .Where(x => customerIds.Contains(x.Cid))
                .Select(x =>
                new CustomerViewModel
                {
                    Cid = x.Cid,
                    Name = x.Name,
                    VisitsMade = x.VisitsMade,
                    LastVisitDate = x.LastVisitDate,
                    Telephone = x.Telephone

                }).ToListAsync();
        }
    }

}