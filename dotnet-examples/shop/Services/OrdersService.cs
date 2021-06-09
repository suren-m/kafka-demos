using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Shop.Services
{
    public enum OrderType
    {
        Default,
        DiscountSale,
        BulkOrder
    }

    public class OrdersService
    {
        public HttpClient Client { get; }

        private readonly IConfiguration Configuration;

        private readonly string _topic = "orders";
        private readonly string _brokers = "10.0.19.1:9094";

        public OrdersService(HttpClient client, IConfiguration configuration)
        {
            Configuration = configuration;
            client.BaseAddress = new Uri("https://httpbin.org/");
            Client = client;
        }

        public async Task<string> GetSomeText(string base64Str)
        {
            return await Client.GetStringAsync($"base64/{base64Str}");
        }

        private ProducerConfig GetEHConfig()
        {
            string brokerList = Configuration["EH_FQDN"];
            string topic = Configuration["EH_NAME"];
            string password = Configuration["SASL_PASSWORD"];
            var config = new ProducerConfig
            {
                BootstrapServers = brokerList,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = password
            };
            return config;
        }

        public async Task PlaceOrderAsyncEH()
        {
            var config = GetEHConfig();
            await PlaceOrderAsync(config);
        }

        public void PlaceBulkOrdersUsingEventHub(int count)
        {
            var config = GetEHConfig();
            PlaceBulkOrders(count, config);
        }

        public async Task PlaceOrderAsync()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _brokers
            };
            await PlaceOrderAsync(config);
        }

        private async Task PlaceOrderAsync(ProducerConfig config)
        {
            // Note: by default strings are encoded as UTF8.  (JSON, Avro are supported too)
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var msg = new Message<Null, string> { Value = "Order Placed" };

                    // asynchronous wait on delivery report 
                    var dr = await p.ProduceAsync(_topic, msg);

                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        public void PlaceBulkOrders(int count)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _brokers
            };
            PlaceBulkOrders(count, config);
        }

        // Run it in a separate Task to stop it from blocking the main thread.
        private void PlaceBulkOrders(int count, ProducerConfig config)
        {
            Action<DeliveryReport<string, string>> handler = r =>
            {
                if (r.Error.IsError)
                {
                    Console.WriteLine($"Delivery Error: {r.Error.Reason}");
                }
                // send it to another topic or service if needed.
                Console.WriteLine($"Message delivered to {r.TopicPartitionOffset}");
            };

            using (var p = new ProducerBuilder<string, string>(config).Build())
            {
                for (int i = 1; i <= count; ++i)
                {
                    var msg = new Message<string, string>
                    {
                        Key = OrderType.BulkOrder.ToString(),
                        Value = $"BulkOrder-{i}"
                    };
                    p.Produce(_topic, msg, handler);
                }
                // wait for up to 5 seconds for any inflight messages to be delivered.
                p.Flush(TimeSpan.FromSeconds(5));
            }
        }
    }
}
