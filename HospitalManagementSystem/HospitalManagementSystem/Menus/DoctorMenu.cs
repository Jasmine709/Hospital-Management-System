using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Menus
{
    public class DoctorMenu
    {
        private readonly AppointmentData _appointmentData;
        private readonly PatientService _patientService;

        // Constructor
        public DoctorMenu()
        {
            _appointmentData = new AppointmentData();
            _patientService = new PatientService();
        }

        public void ShowDoctorMenu(Doctor doctor)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("|  DOTNET Hospital Management System  |");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|             Doctor Menu             |");
                Console.WriteLine("=======================================");
                Console.WriteLine($"Welcome to DOTNET Hospital Management System {doctor.Name.ToLower()}");
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListDoctorDetails(doctor);
                        break;
                    case "2":
                        ListPatients(doctor);
                        break;
                    case "3":
                        ListAppointments(doctor);
                        break;
                    case "4":
                        CheckParticularPatient(doctor);
                        break;
                    case "5":
                        ListAppointmentsWithPatient(doctor);
                        break;
                    case "6":
                        Console.WriteLine("Logging out...");
                        return; 
                    case "7":
                        Console.WriteLine("Exiting system...");
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // 1. List doctor details
        public void ListDoctorDetails(Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|              My Details             |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine(doctor);
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 2. List patients
        public void ListPatients(Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|             My Patients             |");
            Console.WriteLine("=======================================");
            Console.WriteLine("\nName              | Email Address             | Phone        | Address");
            Console.WriteLine(new string('-', 100));
            
            // ***Call of method overloading1
            // Get all current doctor's appointments
            var appointments = _appointmentData.GetAppointments(doctor);

            // through the appointment and display patient information
            foreach (var appointment in appointments)
            {
                var patient = _patientService.ReadPatientById(appointment.PatientID);
                if (patient != null)
                {
                    Console.WriteLine(patient.ToStringOnlyUser()); 
                }
            }

            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }

        // 3. List appointments
        public void ListAppointments(Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|          All Appointments           |");
            Console.WriteLine("=======================================");
            // ***Call of method overloading1
            var appointments = _appointmentData.GetAppointments(doctor);
            Console.WriteLine();
            string header = $"{"Doctor",-25} | {"Patient",-25} | {"Description"} ";
            string head = header + "\n" + new string('-', 80) ;
            Console.WriteLine(head);
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"{appointment.DoctorName,-25} | {appointment.PatientName,-25} | {appointment.Description}");
            }
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }

        // 4. Check particular patient
        public void CheckParticularPatient(Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|        Check Patient Detials        |");
            Console.WriteLine("=======================================");
            Console.Write("Enter the ID of the patient to check: ");
            string patientId = Console.ReadLine();
            Console.WriteLine();

            // Find the patient by ID
            var patient = _patientService.ReadPatientById(patientId);
            if (patient != null)
            {
                // ***Call of method overloading1
                // Find the patient's appointment to get the appropriate doctor
                var appointments = _appointmentData.GetAppointments(doctor);
                Appointment relatedAppointment = appointments.Find(a => a.PatientID == patient.ID);

                if (relatedAppointment != null)
                {
                    Console.WriteLine(patient);
                }
                else
                {
                    Console.WriteLine("The patient is not associated with any appointments under your name.");
                }
            }
            else
            {
                Console.WriteLine("Error: No patient found with the provided ID.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

    // 5. List appointments with patient
    public void ListAppointmentsWithPatient(Doctor doctor)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|      Appointments With Patient      |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.Write("Enter the ID of the patient you would like to view appointments for: ");
            string patientId = Console.ReadLine();
            Console.WriteLine();
            // Find a patient
            var patient = _patientService.ReadPatientById(patientId); 
            if (patient == null)
            {
                Console.WriteLine("No patient with that ID found. Please try again.");
                return; 
            }

            // ***Call of method overloading2
            // Obtain appointment records according to the patient
            var appointments = _appointmentData.GetAppointments(doctor, patientId);

            // Display reservation details
            if (appointments.Any())
            {
                foreach (var appointment in appointments)
                {
                    Console.WriteLine(appointment.ToString());
                }
            }
            else
            {
                Console.WriteLine("No appointments found with this patient.");
            }

            Console.WriteLine("\n" +
                "Press any key to return to menu.");
            Console.ReadKey();
        }
    }
}
