using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_client1
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = "localhost";
            string userName = "guest";
            string password = "guest";
            string queueName = "prova2";
            const int NUMBER_OF_WORKROLES = 3;
            //Cria a conexão com o RabbitMq
            var factory = new ConnectionFactory()
            {
                HostName = hostName,
                UserName = userName,
                Password = password,
            };
            //Cria a conexão
            IConnection connection = factory.CreateConnection();
            //cria a canal de comunicação com a rabbit mq
            IModel channel = connection.CreateModel();
            var teste = Task.Factory.StartNew(() =>
            {
                lock (channel)
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (sender, ea) =>
                    {
                        var number = Convert.ToInt32(ea.Body.ToArray());
                        if (number == 2)
                        {
                            Console.WriteLine($"Mensagem recebida com o valor: {Encoding.Default.GetString(ea.Body.ToArray())}");

                                //Diz ao RabbitMQ que a mensagem foi lida com sucesso pelo consumidor
                                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: true);
                        }
                    };
                        //ConsumerTags = Guid.NewGuid().ToString(); // Tag de identificação do consumidor no RabbitMQ
                        //Registra os consumidor no RabbitMQ
                        String ConsumerTags = channel.BasicConsume(queueName, false, consumer: consumer);
                }
            });
            Console.Read();
        }
    }
}
