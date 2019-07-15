using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Thrift.Protocol;
using TKBase.Framework.Thrift.Server;
using TKBase.Framework.Thrift.Transport;

namespace TKBase.Framework.Thrift.EventHandler
{
    public class ServerEventHandler : TServerEventHandler
    {
       // public event EventHandler<CreateEventArgs> Created;

        public object createContext(TProtocol input, TProtocol output)
        {
            System.Console.WriteLine("createContext");
            return null;
        }

        public void deleteContext(object serverContext, TProtocol input, TProtocol output)
        {
            throw new NotImplementedException();
        }

        public void preServe()
        {
            System.Console.WriteLine("preServe");
        }

        public void processContext(object serverContext, TTransport transport)
        {
            throw new NotImplementedException();
        }
    }
}
