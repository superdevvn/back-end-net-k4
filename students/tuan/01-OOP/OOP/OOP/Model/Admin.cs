using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    public class Admin: Account
    {
        public string Role { get; set; }

        public override void ShowInfo()
        {
            Console.WriteLine($"Admin: {UserName} -- {Role}");
        }
    }
}
