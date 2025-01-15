using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomerService(ILogger<CustomerService> logger): Customer.CustomerBase
    {
        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel customer = new CustomerModel();

            if (request.UserId == 1)
            {
                customer.FirstName = "abc";
                customer.LastName = "def";
            }
            else
            {
                customer.FirstName = "tuv";
                customer.LastName = "xyz";
            }

            return Task.FromResult(customer);
        }

    }
}
