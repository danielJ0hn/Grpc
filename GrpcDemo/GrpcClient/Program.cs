// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class GrpcClientClass
    {
        static async Task Main(string[] args)
        {
            var input = new HelloRequest { Name = "test" };
            var channel = GrpcChannel.ForAddress("https://localhost:7062");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            Console.Read();
        }
    }
}