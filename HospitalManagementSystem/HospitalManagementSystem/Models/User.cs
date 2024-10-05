using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        // No argument constructor
        public User() { }

        public User(string id, string name, string email, string phone, string address, string password)
        {
            ID = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Password = password;
        }

        // ***overridde
        public override string ToString()
        {
            string header = $"{"Name",-17} | {"Email Address",-25} | {"Phone",-12} | {"Address"}\n";
            header += new string('-', 80) + "\n"; 

            string userInfo = $"{Name,-17} | {Email,-25} | {Phone,-12} | {Address}";


            return header + userInfo;
        }

        // Only information without head
        public string ToStringOnlyUser()
        {
            return $"{Name,-17} | {Email,-25} | {Phone,-12} | {Address}";
        }
    }
}
