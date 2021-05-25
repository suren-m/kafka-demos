using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confluent.Kafka;

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

        private readonly string _topic = "orders";
        private readonly string _brokers = "localhost:9093";

        public OrdersService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://httpbin.org/");
            Client = client;
        }

        public async Task<string> GetSomeText(string base64Str)
        {
            return await Client.GetStringAsync($"base64/{base64Str}");
        }

        public async Task PlaceOrderAsync(OrderType orderType)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _brokers
            };

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

        // Run it in a separate Task to stop it from blocking the main thread.
        public void PlaceBulkOrders(int count)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _brokers
            };

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
