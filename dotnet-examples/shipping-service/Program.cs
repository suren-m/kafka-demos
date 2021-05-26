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

            Console.WriteLine("service starting");
            var shipmentService = new ShipmentService(config);

            Task local = Task.Run(() => shipmentService.ConsumerOrdersLocal());

            Task EH = Task.Run(() => shipmentService.ConsumeOrdersEH());

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args);

    }
}
