using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagementSystem.Menus
{
    public class PatientMenu
    {
        private readonly AppointmentData _appointmentData;
        private DoctorService _doctorService;

        // Constructor
        public PatientMenu()
        {
            _appointmentData = new AppointmentData();
            _doctorService = new DoctorService();
        }

        public void ShowPatientMenu(Patient patient)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("|  DOTNET Hospital Management System  |");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|             Patient Menu            |");
                Console.WriteLine("=======================================");
                Console.WriteLine($"Welcome to DOTNET Hospital Management System {patient.Name.ToLower()}");
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Exit to login");
                Console.WriteLine("6. Exit System");
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListPatientDetails(patient);
                        break;
                    case "2":
                        ListMyDoctorDetails(patient);
                        break;
                    case "3":
                        ListAllAppointments(patient);
                        break;
                    case "4":
                        BookAppointment(patient);
                        break;
                    case "5":
                        Console.WriteLine("Returning to login...");
                        return;
                    case "6":
                        Console.WriteLine("Exiting system...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // 1. List patient details
        public void ListPatientDetails(Patient patient)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|              My Details             |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine($"{patient.Name}'s Details");
            Console.WriteLine();
            Console.WriteLine($"Patient ID: {patient.ID}");
            Console.WriteLine($"Full Name: {patient.Name}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Email: {patient.Email}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // 2. List my doctor details
        public void ListMyDoctorDetails(Patient patient)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|               My Doctor             |");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            var assignedDoctor = _appointmentData.GetDoctorByPatient(patient);

            if (assignedDoctor != null)
            {
                Console.WriteLine("Your doctor:");
                Console.WriteLine();
                Console.WriteLine(assignedDoctor.ToString());
            }
            else
            {
                Console.WriteLine("No doctor assigned to this patient.");
            }
            Console.WriteLine();
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }


        // 3. List all appointments
        public void ListAllAppointments(Patient patient)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|            My Appointment           |");
            Console.WriteLine("=======================================");
           
            Console.WriteLine($"Appointments for {patient.Name}");
            Console.WriteLine();
            
            var appointments = _appointmentData.ReadAllAppointments().Where(a => a.PatientID == patient.ID).ToList();

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found for this patient.");
            }
            else
            {
                string header = $"{"Doctor",-25} | {"Patient",-25} | {"Description"} ";
                string head = header + "\n" + new string('-', 80);
                Console.WriteLine(head);
                // Display all related appointments
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"{appointment.DoctorName,-25} | {appointment.PatientName,-25} | {appointment.Description}");
                }
            }

            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }

        // 4. Book appointment
        public void BookAppointment(Patient patient)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("|  DOTNET Hospital Management System  |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|           Book Appointment          |");
            Console.WriteLine("=======================================");

            // Check whether the user is a registered doctor
            Doctor assignedDoctor = _appointmentData.GetDoctorByPatient(patient);

            // If no doctor is registered, the user is prompted to select a doctor
            if (assignedDoctor == null)
            {
                Console.WriteLine("You are not registered with any doctor! Please choose which doctor you would like to register with:");
                var doctors = _doctorService.ReadAllDoctors();

                for (int i = 0; i < doctors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {doctors[i].Name} | {doctors[i].Email} | {doctors[i].Phone} | {doctors[i].Address}");
                }

                Console.Write("Please choose a doctor: ");
                int doctorChoice = int.Parse(Console.ReadLine()) - 1;

                if (doctorChoice >= 0 && doctorChoice < doctors.Count)
                {
                    assignedDoctor = doctors[doctorChoice];
                    // Patient-physician binding logic
                    Console.WriteLine($"You have registered with {assignedDoctor.Name}");
                }
                else
                {
                    Console.WriteLine("Invalid choice, returning to menu.");
                    return;
                }
            }

            // Enter the reservation information
            Console.WriteLine($"You are booking a new appointment with {assignedDoctor.Name}");
            Console.Write("Enter the appointment date (yyyy-MM-dd): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Description of the appointment: ");
            string description = Console.ReadLine();

            // Create a new reservation
            Appointment newAppointment = new Appointment
            {
                DoctorID = assignedDoctor.ID,
                DoctorName = assignedDoctor.Name,
                PatientID = patient.ID,
                PatientName = patient.Name,
                Date = appointmentDate,
                Description = description
            };

            // Save the reservation
            _appointmentData.WriteAppointment(newAppointment);
            Console.WriteLine("The appointment has been booked successfully.");

            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }
    }
    
}
