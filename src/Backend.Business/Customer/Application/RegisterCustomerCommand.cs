using MediatR;

namespace Backend.Business.Customer.Application
{
    public class RegisterCustomerCommand : IRequest<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}