using System;
using System.Threading.Tasks;

namespace Client
{
    class client
    {
        static async void asynchronousmethod(string login, string pwd, ServiceReference1.Service1Client client)
        {
            Console.WriteLine(await client.CheckLoginAsync(login, pwd));

        }

        static void Main(string[] args)
        {
            var client = new ServiceReference1.Service1Client();
            var login = "";
            var pwd = "";

            do
            {
                Console.WriteLine("Entrez un Login :");

                login = Console.ReadLine();

                if (login != "quit")
                {
                    Console.WriteLine("Entrez un Password :");

                    pwd = Console.ReadLine();

                    Task.Run(()=>asynchronousmethod(login, pwd, client));
                }

            } while (login != "quit");
            

            Console.ReadLine();
        
        }
    }
}
