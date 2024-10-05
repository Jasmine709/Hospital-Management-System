using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Administrator
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}";
        }
    }
}
