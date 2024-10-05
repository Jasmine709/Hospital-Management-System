using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Data
{
    public class AppointmentData
    {
        private readonly string _appointmentFilePath = "appointments.txt";
        private readonly DoctorService _doctorService;

        // ***constructor
        public AppointmentData()
        {
            _doctorService = new DoctorService();
        }

        // Read all appointment information for patient3
        public List<Appointment> ReadAllAppointments()
        {
            var appointments = new List<Appointment>();

            foreach (var line in File.ReadAllLines(_appointmentFilePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 6)
                {
                    var appointment = new Appointment
                    {
                        DoctorID = parts[0],
                        DoctorName = parts[1],
                        PatientID = parts[2],
                        PatientName = parts[3],
                        Date = DateTime.Parse(parts[4]),
                        Description = parts[5]
                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }
        
        //for patient2
        public Doctor GetDoctorByPatient(Patient patient)
        {
            var appointments = ReadAllAppointments();
            var appointment = appointments.FirstOrDefault(a => a.PatientID == patient.ID);

            if (appointment != null)
            {
                return _doctorService.ReadDoctorById(appointment.DoctorID);
            }
            return null;
        }

        // ***overloading1
        // Get appointment information by doctor's name, for doctor2/3/4
        public List<Appointment> GetAppointments(Doctor currentDoctor)
        {
            var appointments = new List<Appointment>();

            foreach (var line in File.ReadAllLines(_appointmentFilePath))
            {
                var parts = line.Split('|');
                if (parts[0] == currentDoctor.ID) 
                {
                    var appointment = new Appointment
                    {
                        DoctorID = parts[0],
                        DoctorName = parts[1],
                        PatientID = parts[2],
                        PatientName = parts[3],
                        Date = DateTime.Parse(parts[4]),
                        Description = parts[5]
                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        // ***overloading2
        // Get appointments related to your current doctor and specific patient for doctor 5
        public List<Appointment> GetAppointments(Doctor currentDoctor, string patientId)
        {
            var appointments = new List<Appointment>();

            foreach (var line in File.ReadAllLines(_appointmentFilePath))
            {
                var parts = line.Split('|');
                if (parts[0] == currentDoctor.ID && parts[2] == patientId)
                {
                    var appointment = new Appointment
                    {
                        DoctorID = parts[0],
                        DoctorName = parts[1],
                        PatientID = parts[2],
                        PatientName = parts[3],
                        Date = DateTime.Parse(parts[4]),
                        Description = parts[5]
                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }


        // Writes reservation information to txt
        public void WriteAppointment(Appointment appointment)
        {
            using (StreamWriter sw = new StreamWriter(_appointmentFilePath, true))
            {
                string line = $"{appointment.DoctorID}|{appointment.DoctorName}|{appointment.PatientID}|{appointment.PatientName}|{appointment.Date:yyyy-MM-dd}|{appointment.Description}";
                sw.WriteLine(line);
            }
        }
    }
}
