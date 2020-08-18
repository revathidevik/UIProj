using EventHubTest.Models;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTest
{
    public class EventHubsHelper
    {
        private static Microsoft.Azure.EventHubs.EventHubClient eventHubClient;

        public static async Task PushMessageToEventHubsAsync(AttachmentMetaData msg, string eventHubConnectionString)
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
            // we are using the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(eventHubConnectionString)
            {
                EntityPath = Constants.EVENT_HUB_NAME
            };

            eventHubClient = Microsoft.Azure.EventHubs.EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

           await  SendMessagesToEventHub(msg);

           await eventHubClient.CloseAsync();
        }

        // Creates an event hub client and sends 100 messages to the event hub.
        private static async Task SendMessagesToEventHub(AttachmentMetaData msg)
        {
            try
            {
                var message = JsonConvert.SerializeObject(msg);

                Console.WriteLine($"Sending message: {message}");

               await eventHubClient.SendAsync(new Microsoft.Azure.EventHubs.EventData(Encoding.UTF8.GetBytes(message)));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }

        }

    }
}
