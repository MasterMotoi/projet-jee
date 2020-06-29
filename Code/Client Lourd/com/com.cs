using System;

namespace com
{
    public class comClass
    {
        public void sendLoginQuery (string[] login)
        {
            var client = new ServiceReference1.Service1Client();
            
            msgStruct msg = new msgStruct();
            
            msg.setInfo("Demande de login");
            msg.setData((object[])login);
            msg.setOperationName("authentification");
            msg.setTokenApp(login[2]);

            //client.CheckLogin(msg);
        }

        public void sendFilesQuery(fileStruct[] filesList)
        {
            msgStruct msg = new msgStruct();

            msg.setInfo("Demande de login");
            msg.setData((object[])filesList);
            msg.setOperationName("Sending files for decryption");
            


        }
    }
}
