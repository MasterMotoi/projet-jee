using System;
using System.Linq;
using com;

namespace Controller
{
    public class controller
    {

        public string checkAndSend(string[] login)
        {
            if (login[0].Contains("@")){
                var com = new comClass();
                //login[2] = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                bool isConnected = com.sendLoginQuery(login);
                if (isConnected)
                {
                    return "connected";
                } else
                {
                    return "wrong";
                }
            } else
            {
                return "no @";
            }
        }

        public bool checkFilesAndSend(model.File[] fileList)
        {
            bool isfull = fileList.Count() == 0 ? false : true;

            if (isfull) {
                var com = new comClass();
                com.sendFilesQuery(fileList);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
