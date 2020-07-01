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
                string msgBack = com.sendLoginQuery(login);
                return msgBack;
            } else
            {
                return "no @";
            }
        }

        public String checkFilesAndSend(String[] fileList)
        {
            bool isfull = fileList.Count() == 0 ? false : true;

            if (isfull) {
                var com = new comClass();
                string msgBack = com.sendFilesQuery(fileList);
                return msgBack;
            } else
            {
                return "noFiles";
            }
        }
    }
}
