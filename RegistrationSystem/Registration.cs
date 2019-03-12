using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Newtonsoft.Json;
using System.IO;

namespace RegistrationSystem
{
    public class Registration
    {
        #region fields
        private string _login;
        private string _password;
        private String _fullName;
        private int _age;
        private string _repeatPassword;
        private string _phoneNumber;
        private Random rnd = new Random(1000);
        private int _code;
        private int _enterCode;
        private const int _NORMAL_PASSWORD_NUM = 6;
        private const int _PHONE_SYM_NUMBER = 10;
        #endregion
        User user = new User();
        MessageSender messageSender = new MessageSender();
        CheckPhone checkPhone = new CheckPhone();
        CheckPassword checkPassword = new CheckPassword();


     
        public void StartRegistration()
        {

            WriteLine("\t\t\t\tREGISTRATION");

            Write("Your full name:");
            _fullName = ReadLine();
            while (string.IsNullOrEmpty(_fullName)||_fullName.Length<2)
            {
                Write("Enter your full name correctly:");
                _fullName = ReadLine();
            }
            user.FullName = _fullName;
            
            Write("Your age:");
      
            while (!int.TryParse(ReadLine(), out _age))
            {
            
                 Write("Enter your age correctly:");
                int.TryParse(ReadLine(), out _age);

            }
            user.Age = _age;

            Write("Login: ");
            _login = ReadLine();

            while (string.IsNullOrEmpty(_login) || _login.Length < _NORMAL_PASSWORD_NUM)
            {
                Write("Sorry, enter your login correctly!\n");
                Write("Login: ");
                _login = ReadLine();
            }
            user.Login = _login;

            Write("Password: ");
            checkPassword.Check(ref _password, ref _repeatPassword);
            user.Password = _password;

            Write("Phone number: ");
            checkPhone.Check(ref _phoneNumber);
           // user.PhoneNumber = _phoneNumber;

            _code = 1515;

            try
            {
                messageSender.SendMessage(_phoneNumber, _code);
            }
            catch
            {
                Write("Something went wrong! Try again.");
                Write("Phone number: ");
                checkPhone.Check(ref _phoneNumber);
            }
            user.PhoneNumber = _phoneNumber;

            Write("Enter code: ");
            _enterCode = int.Parse(ReadLine());

            if(_enterCode == _code)
            {
                Write("Registration successfully completed!");
            }
            else 
                while(!(_enterCode==_code))
                {

                    Write("Something went wrong!" +
                      "Enter code: ");
                    _enterCode = int.Parse(ReadLine());
                }

            List<User> users = new List<User>();
            users.Add(user);
            var json = File.ReadAllText(@"D:\path.txt");
            var customers = JsonConvert.DeserializeObject<List<User>>(json);
            customers.Add(user);
            File.WriteAllText(@"D:\path.txt", JsonConvert.SerializeObject(customers));

        }
    }
}