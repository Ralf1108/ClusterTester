﻿using System;
using Akka.Actor;
using Akka.Cluster;
using Akka.Event;

namespace ClusterTester
{
    public class SimpleClusterListener : UntypedActor
    {
        protected ILoggingAdapter Log = Context.GetLogger();
        protected Akka.Cluster.Cluster Cluster = Akka.Cluster.Cluster.Get(Context.System);

        /// <summary>
        /// Need to subscribe to cluster changes
        /// </summary>
        protected override void PreStart()
        {
            Cluster.Subscribe(Self, ClusterEvent.InitialStateAsEvents, new[] { typeof(ClusterEvent.IMemberEvent), typeof(ClusterEvent.UnreachableMember) });
        }

        /// <summary>
        /// Re-subscribe on restart
        /// </summary>
        protected override void PostStop()
        {
            Cluster.Unsubscribe(Self);
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case ClusterEvent.MemberUp up:
                {
                    var mem = up;
                    Console.WriteLine("Member is Up: {0}", mem.Member);
                    break;
                }
                case ClusterEvent.UnreachableMember unreachable:
                    Console.WriteLine("Member detected as unreachable: {0}", unreachable.Member);
                    break;
                case ClusterEvent.MemberRemoved removed:
                    Console.WriteLine("Member is Removed: {0}", removed.Member);
                    break;
                case ClusterEvent.IMemberEvent _:
                    //IGNORE                
                    break;
                case ClusterEvent.CurrentClusterState _:
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }
    }
}

