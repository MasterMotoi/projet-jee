using System;

namespace com
{
    public class comClass
    {
        public void sendLoginQuerry (string[] login)
        {
            var client = new ServiceReference1.Service1Client();
            
            msgStruct msg = new msgStruct();
            
            msg.setInfo("Demande de login");
            msg.setData((object[])login);
            msg.setOperationName("authentificati on");
            msg.setTokenApp(login[2]);

            //client.CheckLogin(msg);
        }
    }
}
