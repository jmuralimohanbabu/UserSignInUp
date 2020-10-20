using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Backend.Business.Customer.Application
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, string>
    {
        public Task<string> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            // #2 check if user already exist in Cognito
            
            // #1 if new user, create a user in Cognito
            
            // #3 save user to DB

            throw new System.NotImplementedException();
        }
    }
}