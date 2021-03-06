﻿using System;
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
                ChannelFactory<servC.I_Server> channelFactory = new ChannelFactory<servC.I_Server>(binding, epServ);
                servC.I_Server _clientProxy = channelFactory.CreateChannel();
                /*
                //authentification
                Console.WriteLine("calling server");
                msg.info = "auth_request";
                msg.tokenApp= "?h:XPjO9b)z3Ox7";
                msg.tokenUser = null;
                msg.appVersion = "1.0";
                msg.operationVersion = "1.0";
                msg.operationName ="auth";
                msg.data = new object[3] { (object)"tom.brunetti@viacesi.fr", (object)"tomb", (object)"?h:XPjO9b)z3Ox7" };
                returnMsg = _clientProxy.server(msg);
                Console.WriteLine("Server call finished");
                Console.WriteLine(returnMsg.info);
                
                //decryption
                Console.WriteLine("calling server");
                msg.info = "auth_request";
                msg.tokenApp = "?h:XPjO9b)z3Ox7";
                msg.tokenUser = null;
                msg.appVersion = "1.0";
                msg.operationVersion = "1.0";
                msg.operationName = "decrypt";
                msg.data = new object[] { (object)"tom.brunetti@viacesi.fr", (object)"?h:XPjO9b)z3Ox7", (object)"file1.txt|sdgshktsh", (object)"file2.txt|dsqg", (object)"file2.txt|gsg"  };
                returnMsg = _clientProxy.server(msg);
                Console.WriteLine("Server call finished");
                Console.WriteLine(returnMsg.info);*/

                //notification
                Console.WriteLine("calling server");
                msg.info = "notif_request";
                msg.tokenApp = "?h:XPjO9b)z3Ox7";
                msg.tokenUser = "'Z|1li:GZ3VW<^3";
                msg.appVersion = "1.0";
                msg.operationVersion = "1.0";
                msg.operationName = "notif";
                msg.data = new object[] { (object)"true", (object)"textfile.txt|fichier décrypté", (object)"AADC", (object)80};
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
