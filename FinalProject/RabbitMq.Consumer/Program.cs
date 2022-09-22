using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitMq.Consumer
{
    public class LoanRequest
    {
        public string Instance { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal LoanAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public int Index { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Loan", durable: false, exclusive: false, autoDelete: false, arguments: null);


                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {

                    try
                    {
                        byte[] body = ea.Body.ToArray();
                        string message = Encoding.UTF8.GetString(body);
                        LoanRequest item = JsonConvert.DeserializeObject<LoanRequest>(message);

                        Console.WriteLine($"Instance={item.Instance} Index:{item.Index} ID:{item.ID} Loan Amount :{item.LoanAmount} NumberOfInstallments:{item.NumberOfInstallments} ");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                  
                    Thread.Sleep(1000);
                };
                channel.BasicConsume(queue: "Loan", autoAck: true, consumer: consumer);

            }

            Console.ReadLine();

        }
    }
}
