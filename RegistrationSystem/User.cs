using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace RegistrationSystem
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public String FullName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

       
    }
}


