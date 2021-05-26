using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace shipping_service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            // Application code should start here.
            Console.WriteLine("service starting");
            var shipmentService = new ShipmentService(config);
            shipmentService.Consume_Orders();

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args);

    }
}
