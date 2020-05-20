using System;
using System.Configuration;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using Samples.Cluster.Simple;

namespace ClusterTester
{
    class Program
    {
        // parameter: port seed-port seed-address
        private static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Please provide parameters: port seed-port seed-address");
                return;
            }

            StartUp(args[0],args[1],args[2]);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        public static void StartUp(string port, string seedPort, string seedAddress)
        {
            var section = (AkkaConfigurationSection)ConfigurationManager.GetSection("akka");

            //Override the configuration of the port
            var config1 = ConfigurationFactory.ParseString("akka.remote.dot-netty.tcp.port=" + port);
            var config2 = ConfigurationFactory.ParseString($"akka.cluster.seed-nodes=[\"akka.tcp://ClusterSystem@{seedAddress}:{seedPort}\"]");
            
            var config = config1
                    .WithFallback(config2)
                    .WithFallback(section.AkkaConfig);

            //create an Akka system
            var system = ActorSystem.Create("ClusterSystem", config);

            //create an actor that handles cluster domain events
            system.ActorOf(Props.Create(typeof(SimpleClusterListener)), "clusterListener");
        }
    }
}
