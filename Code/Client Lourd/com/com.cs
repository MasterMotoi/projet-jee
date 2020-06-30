﻿using System;
using System.Collections.Generic;
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
        }

        public void sendFilesQuery(String[] filesList)
        {
            model.MsgStruct msg = new model.MsgStruct();
           
            EndpointAddress epServ = new EndpointAddress("net.tcp://localhost:8020/Server/services/server");
            NetTcpBinding binding = new NetTcpBinding();

            model.MsgStruct msgBack = new model.MsgStruct();

            try
            {
                ChannelFactory<servC.I_Server> channelFactory = new ChannelFactory<servC.I_Server>(binding, epServ);
                servC.I_Server _clientProxy = channelFactory.CreateChannel();

                msg.info = "Sending files for decryption";
                List<object> data = new List<object>();
                data.Add((object)"'Z|1li:GZ3VW<^3");
                data.Add((object)"tokenApp");
                foreach(object file in filesList)
                {
                    data.Add((object)file);
                }
                msg.data = data.ToArray();
                msg.operationName = "decrypt";
                msg.tokenApp = tokenApp;
                //msg.tokenUser = tokenUser;
                msg.tokenUser = "'Z|1li:GZ3VW<^3";
                msgBack = _clientProxy.server(msg);
                Console.ReadLine();
                //return (bool)msgBack.data[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return false;
            }
        }

        //static async void sendFiles 
    }
}
