# Hospital Management System

Project Duration: Aug 2024

A lightweight hospital information management system developed in **C#**, demonstrating object-oriented programming (OOP), modular system design, data persistence, and console-based user interaction.

This project simulates the essential administrative functions of a hospital, including managing doctors, patients, and appointments. It was developed as part of coursework and serves as a demonstration of structured C# application development.

## Features

### **Doctor Management**
- Add new doctors  
- View all registered doctors  
- Search doctor by ID  
- Basic attributes: Name, Specialization, Availability

### **Patient Management**
- Register new patients  
- View patient list  
- Search patient by ID  
- Basic attributes: Name, Gender, Age, Medical History

### **Appointment Management**
- Schedule an appointment  
- View all appointments  
- Check doctor availability  
- Link appointments to patients & doctors

### **Authentication Layer**
- Role-based login (Admin / Staff)
- Simple console-based identity check

### **Data Persistence**
- Save and load system data using text-based storage
- Ensures all records persist between program executions

## Project Structure

```bash
HospitalManagementSystem/
│
├── Models/
│ ├── Doctor.cs
│ ├── Patient.cs
│ └── Appointment.cs
│
├── Services/
│ ├── DoctorService.cs
│ ├── PatientService.cs
│ └── AppointmentService.cs
│
├── Data/
│ ├── DataStorage.cs
│
├── UI/
│ ├── MainMenu.cs
│ └── InputHelper.cs
│
└── Program.cs
```

##  How to Run

### **Option 1 — Using Visual Studio**
1. Clone the repository
2. Open the solution in Visual Studio
3. Build the project  
4. Run using `Ctrl + F5`

### **Option 2 — Using .NET CLI**
```bash
git clone https://github.com/Jasmine709/HospitalManagementSystem_CSharp.git
cd HospitalManagementSystem_CSharp
dotnet build
dotnet run
```
## Sample Workflow

1. Login as Admin  
2. Add doctors and patients  
3. Create appointments  
4. View system summary  
5. Save & exit (data stored to text files)

## Skills Demonstrated

- C# fundamentals  
- Object-oriented programming (OOP)  
- Class design & service-oriented structure  
- Console UI design  
- File-based persistence  
- Input validation & simple authentication  
- System modelling concepts (doctor/patient/appointment entities)

## Limitations & Future Improvements

### Current Limitations
- Storage uses plain text instead of a database  
- Console UI only (no GUI or web interface)  
- No concurrency or multi-user support  

### Future Enhancements
- Migrate to **ASP.NET Core Web App**  
- Replace text storage with **SQL Server / SQLite**  
- Add REST API endpoints  
- Add role-based authentication using Identity  
- Build a front-end (React / Blazor WebAssembly)  
- Dockerize the system  
- Deploy to Azure / AWS  

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
