using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationParserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample notification titles to test
            TestNotificationParsing("[FE][hello][Urgent] there is testing[BE][QA]");
            TestNotificationParsing("[FE][Urgent][BE] there is testing");
            TestNotificationParsing("[BE][FE][Urgent] there is error");
            TestNotificationParsing("[BE][QA][HAHA][Urgent] there is error");
            TestNotificationParsing("[FE][Urgent][QA] New feature deployed");

            // Prevent console from closing immediately
            Console.ReadLine();
        }

        static void TestNotificationParsing(string notification)
        {
            // Declare list of recognized channels in a defined order
            List<string> channelsList = new List<string> { "BE", "FE", "QA", "Urgent" };

            // Declare HashSet to store channels without duplicates
            HashSet<string> foundChannels = new HashSet<string>();

            // Split the notification string by square brackets
            string[] components = notification.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            // Process each component to identify valid channels
            foreach (var component in components)
            {
                string currentChannel = component.Trim();
                if (channelsList.Contains(currentChannel))
                {
                    foundChannels.Add(currentChannel); // Add unique channel
                }
            }

            // Create a list to hold the sorted channels
            List<string> orderedChannels = new List<string>();

            // Order channels based on their defined sequence
            foreach (string channel in channelsList)
            {
                if (foundChannels.Contains(channel)) // If it was detected, add to the ordered list
                {
                    orderedChannels.Add(channel);
                }
            }

            // Display the result
            Console.WriteLine("Receive channels: " + string.Join(", ", orderedChannels));
        }
    }
}
