using System;
using System.Collections.Generic;
using System.IO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{
    public class UserData : IDisposable
    {
        // Dictionaries store data for administrators, doctors, and patients
        private Dictionary<string, Administrator> administrators = new Dictionary<string, Administrator>();
        private Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patients = new Dictionary<string, Patient>();

        // ***Exception handling
        // Method to load all data
        public void LoadAllData()
        {
            try
            {
                LoadAdministrators();
                LoadDoctors();
                LoadPatients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        // ***Exception handling
        // Load administrator data
        private void LoadAdministrators()
        {
            try
            {
                string[] lines = File.ReadAllLines("admins.txt");
                foreach (string line in lines)
                {
                    string[] data = line.Split('|');
                    if (data.Length < 3)
                    {
                        Console.WriteLine($"Invalid administrator data: {line}");
                        continue;
                    }

                    Administrator admin = new Administrator
                    {
                        ID = data[0],
                        Password = data[1],
                        Name = data[2]
                    };
                    administrators.TryAdd(admin.ID, admin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading administrators: {ex.Message}");
            }
        }

        // ***Exception handling
        // Load doctor data
        private void LoadDoctors()
        {
            try
            {
                string[] lines = File.ReadAllLines("doctors.txt");
                foreach (string line in lines)
                {
                    string[] data = line.Split('|');
                    if (data.Length < 6)
                    {
                        Console.WriteLine($"Invalid doctor data: {line}");
                        continue;
                    }

                    Doctor doctor = new Doctor
                    {
                        ID = data[0],
                        Password = data[1],
                        Name = data[2],
                        Email = data[3],
                        Phone = data[4],
                        Address = data[5]
                    };
                    doctors.TryAdd(doctor.ID, doctor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading doctors: {ex.Message}");
            }
        }

        // ***Exception handling
        // Load patient data
        private void LoadPatients()
        {
            try
            {
                string[] lines = File.ReadAllLines("patients.txt");
                foreach (string line in lines)
                {
                    string[] data = line.Split('|');
                    if (data.Length < 6)
                    {
                        Console.WriteLine($"Invalid patient data: {line}");
                        continue;
                    }

                    Patient patient = new Patient
                    {
                        ID = data[0],
                        Password = data[1],
                        Name = data[2],
                        Email = data[3],
                        Phone = data[4],
                        Address = data[5]
                    };
                    patients.TryAdd(patient.ID, patient);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading patients: {ex.Message}");
            }
        }

        // Verify administrator login
        public bool ValidateAdministrator(string id, string password)
        {
            return administrators.ContainsKey(id) && administrators[id].Password == password;
        }

        // Verify the doctor's login
        public bool ValidateDoctor(string id, string password)
        {
            return doctors.ContainsKey(id) && doctors[id].Password == password;
        }

        // Verify the patient's login
        public bool ValidatePatient(string id, string password)
        {
            return patients.ContainsKey(id) && patients[id].Password == password;
        }

        // Get the administrator object based on its ID
        public Administrator GetAdministratorById(string id)
        {
            administrators.TryGetValue(id, out Administrator admin);
            return admin;
        }

        // Get doctor object based on ID
        public Doctor GetDoctorById(string id)
        {
            doctors.TryGetValue(id, out Doctor doctor);
            return doctor;
        }

        // Get patient object based on ID
        public Patient GetPatientById(string id)
        {
            patients.TryGetValue(id, out Patient patient);
            return patient;
        }



        // ***garbage collection
        // Implement IDisposable to clean up any resources

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                administrators.Clear();
                doctors.Clear();
                patients.Clear();
            }

            disposed = true;
        }

        ~UserData()
        {
            Dispose(false);
        }
    }
}
