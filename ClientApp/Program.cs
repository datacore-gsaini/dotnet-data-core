using DataHubServiceSubscriberContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{

    class SystemDataHubServerProxy : ClientBase<ISubScriber>, ISubScriber
    {
        public SystemDataHubServerProxy(string endpointName) : base(endpointName)
        {
        }

        public string Subscribe()
        {
           return Channel.Subscribe();
        }

        public bool UnSubscribe(string token)
        {
           return Channel.UnSubscribe(token);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new SystemDataHubServerProxy("tcpep");
            var token = proxy.Subscribe();
            Thread.Sleep(1000);
            proxy.UnSubscribe(token);
            Console.Read();
        }
    }
}
