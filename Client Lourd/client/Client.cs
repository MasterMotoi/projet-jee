using System;
using controller;

namespace client
{
    class Client
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference2.Service1Client();
            var input = "";
            controllerClass ctrl = new controllerClass();

            do
            {

                Console.WriteLine("login :");
                input = Console.ReadLine();
                
                if (input != "quit")
                {
                    Console.WriteLine(client.CheckLogin(input));
                }

            } while (input != "quit");

            ctrl.sayHello();

            Console.ReadLine();

            client.CloseAsync();                                                                                    
        }
    }
}
