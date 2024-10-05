using System;
using System.Collections.Generic;
using System.IO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services
{
    public class PatientService
    {
        private readonly string _patientFilePath = "patients.txt";

        // Read all patient information
        public List<Patient> ReadAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            if (!File.Exists(_patientFilePath))
                return patients;

            foreach (var line in File.ReadAllLines(_patientFilePath))
            {
                var parts = line.Split('|');
                Patient patient = new Patient
                {
                    ID = parts[0],
                    Password = parts[1],
                    Name = parts[2],
                    Email = parts[3],
                    Phone = parts[4],
                    Address = parts[5]
                };
                patients.Add(patient);
            }

            return patients;
        }

        // Display all patient information
        public void ListAllPatients()
        {
            List<Patient> patients = ReadAllPatients();

            Console.WriteLine("Name              | Email Address             | Phone        | Address");
            Console.WriteLine(new string('-', 100));

            foreach (var patient in patients)
            {
                Console.WriteLine(patient.ToStringOnlyUser());
            }
        }

        // Obtain patient information according to ID
        public Patient ReadPatientById(string id)
        {
            foreach (var line in File.ReadAllLines(_patientFilePath))
            {
                var parts = line.Split('|');
                if (parts[0] == id)
                {
                    return new Patient
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

        // Write patient information to file
        public void WritePatient(Patient patient)
        {
            using (StreamWriter sw = new StreamWriter(_patientFilePath, true))
            {
                string line = $"{patient.ID}|{patient.Password}|{patient.Name}|{patient.Email}|{patient.Phone}|{patient.Address}";
                sw.WriteLine(line);
            }
        }

        // Obtain patient information by name
        public Patient ReadPatientByName(string name)
        {
            foreach (var line in File.ReadAllLines(_patientFilePath))
            {
                var parts = line.Split('|');
                if (parts[2] == name)
                {
                    return new Patient
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
    }
}
