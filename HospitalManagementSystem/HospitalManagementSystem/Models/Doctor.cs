using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    // ***1 example of inheritance
    public class Doctor : User
    {
        public Doctor() { }

        public override string ToString()
        {
            // head
            string header = $"{"Name",-17} | {"Email Address",-25} | {"Phone",-12} | {"Address"}\n";
            header += new string('-', 100) + "\n"; 

            // user information
            string userInfo = $"{Name,-17} | {Email,-25} | {Phone,-12} | {Address}";

            return header + userInfo;
        }  
    }
}
