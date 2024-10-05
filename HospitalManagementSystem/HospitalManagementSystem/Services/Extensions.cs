using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services
{
    public static class DoctorExtensions
    {
        // ***Extension method: Display doctor details
        public static string DisplayDoctorDetails(this Doctor doctor)
        {
            return $"{doctor.Name,-17} | {doctor.Email,-25} | {doctor.Phone,-12} | {doctor.Address}";
        }
    }
}