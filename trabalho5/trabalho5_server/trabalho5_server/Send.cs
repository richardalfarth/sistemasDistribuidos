namespace trabalho4_server
{
    using System;
    using RabbitMQ.Client;
    using System.Text;

    public class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Pro Pessoal da Comiiitiiivaaa!";
                int count = 1000;
                for (int i = 0; i < count; i++)
                {
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "amq.topic",
                                         routingKey: "routing.topic",
                                         basicProperties: null,
                                         body: body);
                    if(i == count-1)
                    {
                        Console.WriteLine(" [x] Passa Lá na Cooper e pega as Sobras  {0}", message);
                    } else
                    {
                        Console.WriteLine(" [x] Da um Oi {0}", message);
                    }
                   
                }
               
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
