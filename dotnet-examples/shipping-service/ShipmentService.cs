using System;
using System.Threading;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace shipping_service
{
    public class ShipmentService
    {
        private readonly IConfiguration Configuration;

        private readonly string _topic = "orders";
        private readonly string _group = "shipment-service";
        private readonly string _brokerlist;

        public ShipmentService(IConfiguration configuration)
        {
            Configuration = configuration;
            _brokerlist = Configuration["EH_FQDN"];
        }

        private ConsumerConfig GetConsumerConfig()
        {
            string brokerList = Configuration["EH_FQDN"];
            string topic = Configuration["EH_NAME"];
            string password = Configuration["SASL_PASSWORD"];
            var config = new ConsumerConfig
            {
                BootstrapServers = brokerList,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SocketTimeoutMs = 60000,
                SessionTimeoutMs = 30000,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = password,
                GroupId = _group,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            return config;
        }

        public void Consume_Orders()
        {
            var config = GetConsumerConfig();
            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

                consumer.Subscribe(_topic);

                Console.WriteLine("Consuming messages from topic: " + _topic + ", broker(s): " + _brokerlist);

                while (true)
                {
                    try
                    {
                        var msg = consumer.Consume(cts.Token);
                        Console.WriteLine($"Received: '{msg.Message.Value}'");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consume error: {e.Error.Reason}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
        }
    }
}