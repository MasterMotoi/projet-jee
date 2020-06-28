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
            EndpointAddress epServ = new EndpointAddress("http://localhost:8010/Server/services/server");
            model.MsgStruct msg = new model.MsgStruct();
            model.MsgStruct returnMsg = new model.MsgStruct();
            try
            { 
                servC.I_Server proxyServC = ChannelFactory<servC.I_Server >.CreateChannel(new BasicHttpBinding(), epServ);
                Console.WriteLine("calling server");
                //msg.statutOp = null;
                msg.info = "auth_request";
                msg.tokenApp= "123456";
                msg.tokenUser = null;
                msg.appVersion = "1.0";
                msg.operationVersion = "1.0";
                msg.operationName ="auth";
                msg.data = new object[3] { (object)"login", (object)"password",(object)"123456" };
                returnMsg = proxyServC.server(msg);
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
