using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService(ILogger<CustomersService> logger): Customer.CustomerBase
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

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "abc",
                    LastName = "def",
                    EmailAddress = "abcdef@gmail.com",
                    Age = 100
                },
                new CustomerModel
                {
                    FirstName = "ghi",
                    LastName = "jkl",
                    EmailAddress = "ghijkl@gmail.com",
                    Age = 100
                }
            };

            foreach (var customer in customers)
            {
                await responseStream.WriteAsync(customer);
            }
        }
    }
}
