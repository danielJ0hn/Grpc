// See https://aka.ms/new-console-template for more information

using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class GrpcClientClass
    {
        static async Task Main(string[] args)
        {
            var request = new CustomerLookupModel { UserId = 2 };

            var channel = GrpcChannel.ForAddress("https://localhost:7062");
            var client = new Customer.CustomerClient(channel);

            var reply = await client.GetCustomerInfoAsync(request);

            Console.WriteLine($"{reply.FirstName} {reply.LastName}");

            using (var call = client.GetNewCustomers(new NewCustomerRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var current = call.ResponseStream.Current;
                    Console.WriteLine($"{current.FirstName} {current.LastName}: {current.EmailAddress}");
                }
            }

            Console.Read();
        }
    }
}