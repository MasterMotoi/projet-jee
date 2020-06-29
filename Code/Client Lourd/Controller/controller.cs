using System;
using System.Linq;
using com;

namespace Controller
{
    public class controller
    {

        public void checkAndSend(string[] login)
        {
            if (login[0].Contains("@")){
                var com = new comClass();
                login[2] = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                com.sendLoginQuery(login);
            } else
            {
                Console.WriteLine("Le login devrait être un mail.");
            }
        }

        public bool checkFilesAndSend(fileStruct[] fileList)
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
