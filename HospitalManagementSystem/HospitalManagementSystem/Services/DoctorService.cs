using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using HospitalManagementSystem.Models;


namespace HospitalManagementSystem.Services
{
    public class DoctorService
    {
        private readonly string _doctorFilePath = "doctors.txt";

        // Read all doctor information
        public List<Doctor> ReadAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            if (!File.Exists(_doctorFilePath))
                return doctors;

            foreach (var line in File.ReadAllLines(_doctorFilePath))
            {
                var parts = line.Split('|');
                Doctor doctor = new Doctor
                {
                    ID = parts[0],
                    Password = parts[1],
                    Name = parts[2],
                    Email = parts[3],
                    Phone = parts[4],
                    Address = parts[5]
                };
                doctors.Add(doctor);
            }

            return doctors;
        }

        // Display all doctor information
        public void ListAllDoctors()
        {
            List<Doctor> doctors = ReadAllDoctors();

            Console.WriteLine("Name              | Email Address             | Phone        | Address");
            Console.WriteLine(new string('-', 100)); 

            foreach (var doctor in doctors)
            {
                // ***call Extended method
                Console.WriteLine(doctor.DisplayDoctorDetails());
            }
        }

        // Get doctor information according to ID
        public Doctor ReadDoctorById(string id)
        {
            foreach (var line in File.ReadAllLines(_doctorFilePath))
            {
                var parts = line.Split('|');
                if (parts[0] == id)
                {
                    return new Doctor
                    {
                        ID = parts[0],
                        Password = parts[1],
                        Name = parts[2],
                        Email = parts[3],
                        Phone = parts[4],
                        Address = parts[5]
                    };
                }
            }
            return null;
        }

        // Write the doctor information to the txt
        public void WriteDoctor(Doctor doctor)
        {
            using (StreamWriter sw = new StreamWriter(_doctorFilePath, true))
            {
                string line = $"{doctor.ID}|{doctor.Password}|{doctor.Name}|{doctor.Email}|{doctor.Phone}|{doctor.Address}";
                sw.WriteLine(line);
            }
        }
    }
}

