﻿using System;
using System.IO;
using Dotbot.Example.Parts;
using Dotbot.Slack;
using Microsoft.Extensions.Configuration;

namespace Dotbot.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read the configuration
            var configuration = GetConfiguration();

            // Build the robot.
            var robot = new RobotBuilder()
                .UseSlack(configuration["Slack:Token"])
                .AddPart<PingPart>()
                .Build();

            // Start the robot.
            robot.Start();

            // Setup cancellation.
            Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                robot.Stop();
            };

            // Wait for termination.
            robot.Join();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
