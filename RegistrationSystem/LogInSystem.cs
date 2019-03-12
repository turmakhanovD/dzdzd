using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace RegistrationSystem
{
    public class LogInSystem
    {
        public string Login { get; set; }
        public string Password { get; set; }
        User user = new User();
        public void LogIn()
        {

            using (var streamReader = new StreamReader(@"D:\path.txt"))
            {
                var result = streamReader.ReadToEnd();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(result);
                Console.WriteLine(result.ToString());
           

            Login = Console.ReadLine();
                if (users.Contains(new User { Login = Login }))
                {
                    Password = Console.ReadLine();
                    if(users.Contains(new User { Password = Password}))
                    {
                        Console.WriteLine("yeah1");
                    }
                }
                else { }
                
                        
            }
        }
    }
}
