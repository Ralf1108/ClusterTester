using System;
using System.Configuration;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;

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

            var port = args[0];
            var seedPort = args[1];
            var seedAddress = args[2];
            var system = StartUp(port, seedPort, seedAddress);

            if (port != seedPort)
            {
                var remoteAddress = new Address("akka.tcp", "ClusterSystem", seedAddress, Convert.ToInt32(seedPort));
                var remotePingActor = system.ActorOf(Props.Create(() => new PingPongActor())
                    .WithDeploy(Deploy.None.WithScope(new RemoteScope(remoteAddress))));

                var localPingActor = system.ActorOf(Props.Create(() => new PingPongActor(remotePingActor)));
            }


            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        public static ActorSystem StartUp(string port, string seedPort, string seedAddress)
        {
            var section = (AkkaConfigurationSection) ConfigurationManager.GetSection("akka");

            //Override the configuration of the port
            var config1 = ConfigurationFactory.ParseString("akka.remote.dot-netty.tcp.port=" + port);
            var config2 =
                ConfigurationFactory.ParseString(
                    $"akka.cluster.seed-nodes=[\"akka.tcp://ClusterSystem@{seedAddress}:{seedPort}\"]");

            var config = config1
                .WithFallback(config2)
                .WithFallback(section.AkkaConfig);

            //create an Akka system
            var system = ActorSystem.Create("ClusterSystem", config);

            //create an actor that handles cluster domain events
            system.ActorOf(Props.Create(typeof(SimpleClusterListener)), "clusterListener");

            return system;
        }
    }

    class PingPongActor : ReceiveActor
    {
        private readonly IActorRef _remotePingActor;
        private int _idCounter;

        public PingPongActor(IActorRef remotePingActor)
        {
            _remotePingActor = remotePingActor;
            if (!_remotePingActor.Equals(ActorRefs.Nobody))
            {
                Context.System.Scheduler.ScheduleTellRepeatedly(
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(1),
                    Self,
                    Tick.Instance,
                    Self);
            }

            Become(State_Ready);
        }

        public PingPongActor()
            : this(ActorRefs.Nobody)
        {
        }

        private void State_Ready()
        {
            Receive<Ping>(x =>
            {
                Console.WriteLine($"{Now()} - Send pong {x.Id} from {Sender}");
                Sender.Tell(new Pong(x.Id));
            });

            Receive<Pong>(x =>
            {
                Console.WriteLine($"{Now()} - Got pong {x.Id}");
            });

            Receive<Tick>(x =>
            {
                _idCounter++;
                Console.WriteLine($"{Now()} - Send ping {_idCounter}");
                _remotePingActor.Tell(new Ping(_idCounter));
            });
        }

        private string Now()
        {
            return DateTime.Now.ToString("G");
        }

        internal class Tick
        {
            public static readonly Tick Instance = new Tick();

            private Tick()
            {
            }
        }

        internal class Ping
        {
            public Ping(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        internal class Pong
        {
            public Pong(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}