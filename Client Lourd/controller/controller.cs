using System;
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
                com.sendLoginQuerry(login);
            } else
            {
                Console.WriteLine("Le login devrait être un mail.");
            }
        }

    }
}
