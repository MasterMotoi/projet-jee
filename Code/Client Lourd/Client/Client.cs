using System;
using System.Threading.Tasks;
using Controller;

namespace Client
{
    class client
    {
        /*static async void asynchronousmethod(string[] login, ServiceReference1.Service1Client client)
        {
            Console.WriteLine(await client.CheckLoginAsync(login));

        }*/

        static void Main(string[] args)
        {
            String[] login = new string[3];
            var controller = new controller();
            //var client = new ServiceReference1.Service1Client();

            Console.WriteLine("Entrez un Login :");

            login[0] = Console.ReadLine();

            Console.WriteLine("Entrez un Password :");

            login[1] = Console.ReadLine();

            Console.WriteLine("Connexion en cours...");

            controller.checkAndSend(login);

            //Task.Run(()=>asynchronousmethod(login, client));


            Console.ReadLine();
        
        }
    }
}
