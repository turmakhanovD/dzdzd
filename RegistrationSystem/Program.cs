using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace RegistrationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Registration registration = new Registration();

            LogInSystem logIn = new LogInSystem();

            Console.WriteLine("Social network:\n1.Enter\n2.Register\n3.Exit");
            int choose;
            if (int.TryParse(Console.ReadLine(), out choose) && choose == 2)
            {
                Console.Clear();
                registration.StartRegistration();
            }


            if (int.TryParse(Console.ReadLine(), out choose) && choose == 1)
            {
              Console.Clear();
                logIn.LogIn();
            }



            
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}