using System;
using System.ServiceModel;
using model;

namespace com
{
    public class comClass
    {
        private string tokenApp = "?h:XPjO9b)z3Ox7";
        private string tokenUser = "";

        public bool sendLoginQuery (string[] login)
        {
            //var client = new ServiceReference1.Service1Client();
            
            EndpointAddress epServ = new EndpointAddress("net.tcp://localhost:8020/Server/services/server");
            NetTcpBinding binding = new NetTcpBinding();

            model.MsgStruct msg = new model.MsgStruct();
            model.MsgStruct msgBack = new model.MsgStruct();

            

            try
            {
                ChannelFactory<servC.I_Server> channelFactory = new ChannelFactory<servC.I_Server>(binding, epServ);
                servC.I_Server _clientProxy = channelFactory.CreateChannel();

                msg.info = "Demande de login";
                msg.data = (object[])login;
                msg.operationName = "auth";
                login[2] = tokenApp;
                msg.tokenApp = tokenApp;
                msgBack = _clientProxy.server(msg);
                tokenUser = msgBack.tokenUser;
                return (bool)msgBack.data[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            Console.ReadLine();

           // client.CheckLogin(msg);
        }

        public void sendFilesQuery(model.File[] filesList)
        {
            model.MsgStruct msg = new model.MsgStruct();

            msg.info = "Demande de login";
            msg.data = (object[])filesList;
            msg.operationName = "Sending files for decryption";
            msg.tokenApp = "?h:XPjO9b)z3Ox7";


        }
    }
}
