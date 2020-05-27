# ClusterTester
Testing Akka.Net  Cluster connectivity/reliability

# Usage
Set "akka.remote.dot-netty.tcp.hostname" in "ClusterTester.exe.config" to ip address of current machine or else the cluster won't startup correctly.<br>
Ensure that seed node is reachable from outside, so configure firewall appropriate for open port to the exe file.

Run on seed node: `ClusterTester.exe 10000 10000 10.112.10.181 > _log.txt`

Run on other node: `ClusterTester.exe 11000 10000 10.112.10.181 > _log.txt`

Usage ping to check network health in parallel:<br>
`ping.exe -t 10.112.10.181 |Foreach{"{0} - {1}" -f (Get-Date),$_} >> _ping.txt`


# Seed node log
```
[INFO][07.05.2020 12:17:34][Thread 0001][remoting (akka://ClusterSystem)] Starting remoting
[INFO][07.05.2020 12:17:35][Thread 0001][remoting (akka://ClusterSystem)] Remoting started; listening on addresses : [akka.tcp://ClusterSystem@10.112.10.181:10000]
[INFO][07.05.2020 12:17:35][Thread 0001][remoting (akka://ClusterSystem)] Remoting now listens on addresses: [akka.tcp://ClusterSystem@10.112.10.181:10000]
[INFO][07.05.2020 12:17:35][Thread 0001][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Starting up...
[INFO][07.05.2020 12:17:35][Thread 0001][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Started up successfully
Press any key to exit
[INFO][07.05.2020 12:17:35][Thread 0003][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Node [akka.tcp://ClusterSystem@10.112.10.181:10000] is JOINING itself (with roles []) and forming a new cluster
[INFO][07.05.2020 12:17:35][Thread 0003][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Leader is moving node [akka.tcp://ClusterSystem@10.112.10.181:10000] to [Up]
[INFO][07.05.2020 12:17:35][Thread 0003][akka.tcp://ClusterSystem@10.112.10.181:10000/user/clusterListener] Member is Up: Member(address = akka.tcp://ClusterSystem@10.112.10.181:10000, Uid=1206048204 status = Up, role=[], upNumber=1)
[INFO][07.05.2020 12:17:41][Thread 0005][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Received InitJoin message from [[akka.tcp://ClusterSystem@10.112.10.171:11000/system/cluster/core/daemon/joinSeedNodeProcess-1#980317007]] to [akka.tcp://ClusterSystem@10.112.10.181:10000]
[INFO][07.05.2020 12:17:41][Thread 0005][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Sending InitJoinNack message from node [akka.tcp://ClusterSystem@10.112.10.181:10000] to [[akka.tcp://ClusterSystem@10.112.10.171:11000/system/cluster/core/daemon/joinSeedNodeProcess-1#980317007]]
[INFO][07.05.2020 12:17:41][Thread 0018][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Node [akka.tcp://ClusterSystem@10.112.10.171:11000] is JOINING, roles []
[INFO][07.05.2020 12:17:42][Thread 0018][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Leader is moving node [akka.tcp://ClusterSystem@10.112.10.171:11000] to [Up]
[INFO][07.05.2020 12:17:42][Thread 0018][akka.tcp://ClusterSystem@10.112.10.181:10000/user/clusterListener] Member is Up: Member(address = akka.tcp://ClusterSystem@10.112.10.171:11000, Uid=2052147158 status = Up, role=[], upNumber=2)
[WARNING][08.05.2020 02:31:01][Thread 0066][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2703,15] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][17.05.2020 02:31:06][Thread 0026][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [3596,5893] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][19.05.2020 18:48:49][Thread 0032][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2453,1283] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][19.05.2020 18:49:49][Thread 0031][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2437,5046] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][19.05.2020 18:50:49][Thread 0005][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2000,0024] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][19.05.2020 19:01:50][Thread 0031][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2562,5076] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][20.05.2020 02:31:19][Thread 0039][akka.tcp://ClusterSystem@10.112.10.181:10000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.181:10000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [2656,2562] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.

```


# Other node log
```
[INFO][07.05.2020 12:17:04][Thread 0001][remoting (akka://ClusterSystem)] Starting remoting
[INFO][07.05.2020 12:17:04][Thread 0001][remoting (akka://ClusterSystem)] Remoting started; listening on addresses : [akka.tcp://ClusterSystem@10.112.10.171:11000]
[INFO][07.05.2020 12:17:04][Thread 0001][remoting (akka://ClusterSystem)] Remoting now listens on addresses: [akka.tcp://ClusterSystem@10.112.10.171:11000]
[INFO][07.05.2020 12:17:04][Thread 0001][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Starting up...
Press any key to exit
[INFO][07.05.2020 12:17:04][Thread 0001][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Started up successfully
[INFO][07.05.2020 12:17:05][Thread 0003][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Welcome from [akka.tcp://ClusterSystem@10.112.10.181:10000]
[INFO][07.05.2020 12:17:05][Thread 0015][akka.tcp://ClusterSystem@10.112.10.171:11000/user/clusterListener] Member is Up: Member(address = akka.tcp://ClusterSystem@10.112.10.181:10000, Uid=1206048204 status = Up, role=[], upNumber=1)
[INFO][07.05.2020 12:17:06][Thread 0015][akka.tcp://ClusterSystem@10.112.10.171:11000/user/clusterListener] Member is Up: Member(address = akka.tcp://ClusterSystem@10.112.10.171:11000, Uid=2052147158 status = Up, role=[], upNumber=2)
[WARNING][08.05.2020 10:04:40][Thread 0015][akka.tcp://ClusterSystem@10.112.10.171:11000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [35897,9341] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][08.05.2020 10:07:50][Thread 0022][akka.tcp://ClusterSystem@10.112.10.171:11000/system/cluster/core/daemon/heartbeatSender] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Scheduled sending of heartbeat was delayed. Previous heartbeat was sent [34902,6] ms ago, expected interval is [1000] ms. This may cause failure detection to mark members as unreachable. The reason can be thread starvation, e.g. by running blocking tasks on the default dispatcher, CPU overload, or GC.
[WARNING][20.05.2020 02:30:51][Thread 0004][akka.tcp://ClusterSystem@10.112.10.171:11000/system/cluster/core/daemon] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Marking node(s) as UNREACHABLE [Member(address = akka.tcp://ClusterSystem@10.112.10.181:10000, Uid=1206048204 status = Up, role=[], upNumber=1)]. Node roles []
[INFO][20.05.2020 02:30:51][Thread 0023][akka.tcp://ClusterSystem@10.112.10.171:11000/user/clusterListener] Member detected as unreachable: Member(address = akka.tcp://ClusterSystem@10.112.10.181:10000, Uid=1206048204 status = Up, role=[], upNumber=1)
[INFO][20.05.2020 02:30:52][Thread 0023][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Ignoring received gossip status from unreachable [UniqueAddress: (akka.tcp://ClusterSystem@10.112.10.181:10000, 1206048204)]
[INFO][20.05.2020 02:30:52][Thread 0023][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Ignoring received gossip status from unreachable [UniqueAddress: (akka.tcp://ClusterSystem@10.112.10.181:10000, 1206048204)]
[INFO][20.05.2020 02:30:52][Thread 0004][Cluster (akka://ClusterSystem)] Cluster Node [akka.tcp://ClusterSystem@10.112.10.171:11000] - Marking node(s) as REACHABLE [Member(address = akka.tcp://ClusterSystem@10.112.10.181:10000, Uid=1206048204 status = Up, role=[], upNumber=1)]. Node roles []

```
