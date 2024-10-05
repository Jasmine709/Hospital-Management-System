using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Menus
{
    public class AdministratorMenu
    {
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;

        // Constructor
        public AdministratorMenu()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
        }

        public void ShowAdministratorMenu(Administrator admin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("|  DOTNET Hospital Management System  |");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|          Administrator Menu         |");
                Console.WriteLine("=======================================");
                Console.WriteLine($"Welcome to DOTNET Hospital Management System {admin.Name}");
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. List all doctors");
                Console.WriteLine("2. Check doctor details");
                Console.WriteLine("3. List all patients");
                Console.WriteLine("4. Check patient details");
                Console.WriteLine("5. Add doctor");
                Console.WriteLine("6. Add patient");
                Console.WriteLine("7. Logout");
                Console.WriteLine("8. Exit");
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllDoctors();
                        break;
                    case "2":
                        CheckDoctorDetails();
                        break;
                    case "3":
                        ListAllPatients();
                        break;
                    case "4":
                        CheckPatientDetails();
                        break;
                    case "5":
                        AddDoctor();
                        break;
                    case "6":
                        AddPatient();
                        break;
                    case "7":
                        Console.WriteLine("Logging out...");
                        return; // 返回到登录界面
                    case "8":
                        Console.WriteLine("Exiting system...");
                        Environment.Exit(0); // 结束程序
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // 1. List all doctors
        public void ListAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|             All Doctors             |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("All doctors registered to the DOTNET Hospital Management System");
            Console.WriteLine();
            _doctorService.ListAllDoctors();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 2. Check doctor details
        public void CheckDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|           Doctor Details            |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.Write("Please enter the ID of the doctor whose details you are checking: ");
            Console.WriteLine();
            string doctorId = Console.ReadLine();
            Console.WriteLine();

            var doctor = _doctorService.ReadDoctorById(doctorId);
            if (doctor != null)
            {
                Console.WriteLine($"Detials for {doctor.Name}");
                Console.WriteLine();
                Console.WriteLine(doctor); 
            }
            else
            {
                Console.WriteLine("Doctor not found. Please try again.");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 3. List all patients
        public void ListAllPatients()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|             All Patients            |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("All patients registered to the DOTNET Hospital Management System");
            Console.WriteLine();
            _patientService.ListAllPatients();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 4. Check patient details
        public void CheckPatientDetails()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|           Patient Details            |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.Write("Please enter the ID of the patient whose details you are checking: ");
            Console.WriteLine();
            string patientId = Console.ReadLine();
            Console.WriteLine();

            var patient = _patientService.ReadPatientById(patientId);
            if (patient != null)
            {
                Console.WriteLine($"Detials for {patient.Name}");
                Console.WriteLine();
                Console.WriteLine(patient); 
            }
            else
            {
                Console.WriteLine("Patient not found. Please try again.");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 5. Add doctor
        public void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|             Add Doctor              |");
            Console.WriteLine("=======================================");
            Console.Write("Registering a new doctor with the DOTNET Hospital Management System");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Street Number: ");
            string streetNumber = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();

            Doctor newDoctor = new Doctor
            {
                ID = id,
                Password = password,
                Name = firstName + " " + lastName,
                Email = email,
                Phone = phone,
                Address = streetNumber + " " + street + ", " + city + ", " + state
            };

            _doctorService.WriteDoctor(newDoctor);
            Console.WriteLine();
            Console.WriteLine($"{firstName} {lastName} added to the system!");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 6. Add patient
        public void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|             Add Patient             |");
            Console.WriteLine("=======================================");
            Console.Write("Registering a new patient with the DOTNET Hospital Management System");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Street Number: ");
            string streetNumber = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();

            Patient newPatient = new Patient
            {
                ID = id,
                Password = password,
                Name = firstName + " " + lastName,
                Email = email,
                Phone = phone,
                Address = streetNumber + " " + street + ", " + city + ", " + state
            };

            _patientService.WritePatient(newPatient);
            Console.WriteLine();
            Console.WriteLine($"{firstName} {lastName} added to the system!");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }
    }
}

