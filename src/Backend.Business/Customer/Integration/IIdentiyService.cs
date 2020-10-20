using Backend.Business.Customer.Integration.Models;

namespace Backend.Business.Customer.Integration
{
    public interface IIdentiyService
    {
        public RegisterCustomerResponse RegisterCustomer(RegisterCustomerRequest registerCustomerRequest);
    }
}