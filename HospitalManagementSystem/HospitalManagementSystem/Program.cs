using HospitalManagementSystem.Models;
using System;
using HospitalManagementSystem.Menus;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // ***garbage collection
            // Use the using statement to ensure that userData automatically calls Dispose when it ends
            using (UserData userData = new UserData())
            {
                // Load all user data
                userData.LoadAllData();

                // Enter the login menu
                bool isRunning = true;
                while (isRunning)
                {
                    try
                    {
                        // Create and display the login menu
                        LoginMenu loginMenu = new LoginMenu(userData);
                        isRunning = loginMenu.ShowLoginMenu();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            } // At the end of using, userData.Dispose() is automatically called

            Console.WriteLine("Program has ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
