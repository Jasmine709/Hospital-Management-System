using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    // ***1 example of inheritance
    public class Patient : User
    {
        // Default no-argument constructor
        public Patient() { }

        //Override the ToString() method to print patient information
        public override string ToString()
        {
            string header = $"{"Name",-17} | {"Email Address",-25} | {"Phone",-12} | {"Address"}\n";
            header += new string('-', 100) + "\n";

            string userInfo = $"{Name,-17} | {Email,-25} | {Phone,-12} | {Address}";

            return header + userInfo;
        }
    }
}