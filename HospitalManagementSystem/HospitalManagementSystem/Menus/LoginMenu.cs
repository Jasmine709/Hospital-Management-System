using System;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Menus;

namespace HospitalManagementSystem
{
    public class LoginMenu
    {
        private readonly UserData _userData;

        // constructor, which accepts the UserData object
        public LoginMenu(UserData userData)
        {
            _userData = userData;
        }

        // Display the login menu and perform user authentication
        public bool ShowLoginMenu()
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("|  DOTNET Hospital Management System  |");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|                Login                |");
                Console.WriteLine("=======================================");

                // Get the ID and password entered by the user
                Console.Write("ID: ");
                string id = Console.ReadLine();
                Console.Write("Password: ");
                string password = ReadPassword(); // Hide password input

                // Verify the administrator account
                if (_userData.ValidateAdministrator(id, password))
                {
                    Console.WriteLine("\nValid Credentials");
                    isValid = true;
                    // Get the administrator object and jump to the administrator menu
                    Administrator admin = _userData.GetAdministratorById(id);
                    AdministratorMenu adminMenu = new AdministratorMenu();
                    adminMenu.ShowAdministratorMenu(admin);
                }
                // Verify doctor account
                else if (_userData.ValidateDoctor(id, password))
                {
                    Console.WriteLine("\nValid Credentials");
                    isValid = true;
                    // Get Doctor object and jump to Doctor menu
                    Doctor doctor = _userData.GetDoctorById(id);
                    DoctorMenu doctorMenu = new DoctorMenu();
                    doctorMenu.ShowDoctorMenu(doctor);
                }
                // Verify patient accounts
                else if (_userData.ValidatePatient(id, password))
                {
                    Console.WriteLine("\nValid Credentials");
                    isValid = true;
                    // Get the patient object and jump to the patient menu
                    Patient patient = _userData.GetPatientById(id);
                    PatientMenu patientMenu = new PatientMenu();
                    patientMenu.ShowPatientMenu(patient);
                }
                // Process invalid credentials
                else
                {
                    Console.WriteLine("\nInvalid Credentials");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }
            // If true is returned, the user successfully logs in and can continue with the main program. If false is returned, the user exits
            return isValid;
        }

        // Hide password input
        private string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            return password;
        }
    }
}
