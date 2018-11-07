using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    public class User: Account
    {
        public string Email { get; set; }

        public override void ShowInfo()
        {
            Console.WriteLine($"User: {UserName} -- {Email}");
        }
    }
}
