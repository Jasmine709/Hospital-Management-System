## Overview
The Hospital Management System is a C# application designed to manage hospital operations such as doctor and patient management, appointment scheduling, and user authentication.

## Project Structure
HospitalManagementSystem/
	Data/：Contains classes for handling data storage and retrieval
		AppointmentData.cs：Manages user-related data including administrators, doctors, and patients
		UserData.cs：Handles appointment data storage and retrieval.
	Menus/: Manages the user interface for different user roles.
		AdministratorMenu.cs:Interface for administrators.
		DoctorMenu.cs:Interface for doctors.
		LoginMenu.cs:Handles user login.
		PatientMenu.cs:Interface for patients.
	Models/:Contains class definitions for core data structures.
		Administrator.cs:Administrator data model.
		Appointment.cs:Appointment data model.
		Doctor.cs:Doctor data model.
		Patient.cs:Patient data model.
		User.cs:Base class for user roles.
	Services/:Provides backend services for data manipulation.
		DoctorService.cs:Handles operations related to doctors.
		Extensions.cs:Handles operations related to patients.
		PatientService.cs:Contains extension methods to extend core functionalities.
	Program.cs:Main entry point of the application, initializing data and managing the application flow.

Data File:
\HospitalManagementSystem\bin\Debug\net8.0
	admins.txt
	appointments.txt
	doctors.txt
	patients.txt

## Console Code and Design
OOP Principles Used：
- example of inheritance
	doctor.cs/patient.cs inherits user.cs
- example of method overloading is used
	Defined in appointmentData.cs(GetAppointments fuciton) and invoked in doctorMenu
- example of method overriding is used
	Override toString in user.cs
- example of constructor
	It is used in several classes such as appointmentData.cs
- example of extension method
	Defined in Extensions.cs and called in DoctorService-ListAllDoctors()
- example of garbage collection
	Defined in userData.cs and called in Program.cs

Appropriate use of exception handling：
	userData.cs
