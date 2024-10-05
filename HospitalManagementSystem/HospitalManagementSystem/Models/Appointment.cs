using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string PatientID { get; set; }

        public string PatientName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        // Override the ToString() method to print the reservation information
        public override string ToString()
        {
            string header = $"{"Doctor",-25} | {"Patient",-25} | {"Description"}\n";
            header += new string('-', 80) + "\n";
            string appointmentInfo = $"{DoctorName,-25} | {PatientName,-25} | {Description}";
            return header + appointmentInfo;
        }


    }
}
