using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using servC;
using model;

namespace clientTest
{
    class Program
    {
        

        static void Main(string[] args)
        {
            EndpointAddress epServ = new EndpointAddress("net.tcp://localhost:8020/Server/services/server");
            NetTcpBinding binding = new NetTcpBinding();
            model.MsgStruct msg = new model.MsgStruct();
            model.MsgStruct returnMsg = new model.MsgStruct();
            try
            {
                //servC.I_Server proxyServC = ChannelFactory<servC.I_Server >.CreateChannel(new BasicHttpBinding(), epServ);
                ChannelFactory<servC.I_Server> channelFactory = new ChannelFactory<servC.I_Server>(binding, epServ);
                servC.I_Server _clientProxy = channelFactory.CreateChannel();
                

                Console.WriteLine("calling server");
                //msg.statutOp = null;
                msg.info = "auth_request";
                msg.tokenApp= "123456";
                msg.tokenUser = null;
                msg.appVersion = "1.0";
                msg.operationVersion = "1.0";
                msg.operationName ="auth";
                msg.data = new object[3] { (object)"login", (object)"password",(object)"123456" };
                returnMsg = _clientProxy.server(msg);
                Console.WriteLine("Server call finished");
                Console.WriteLine(returnMsg.info);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
