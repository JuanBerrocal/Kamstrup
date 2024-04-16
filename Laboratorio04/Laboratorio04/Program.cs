using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio04
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public double Temperature { get; set; }
        public int HeartRate { get; set; }
        public string Speciality { get; set; }
        public int Age { get; set; }

        public void cloneFrom(Patient source)
        {
            Id = source.Id;
            Name = source.Name;
            Lastname = source.Lastname;
            Sex = source.Sex;
            Temperature = source.Temperature;
            HeartRate = source.HeartRate;
            Speciality = source.Speciality;
            Age = source.Age;
        }

    }

    internal class Program
    {

        



        static void Main(string[] args)
        {

            var patients = new List<Patient> {
            new Patient {Id = 1, Name = "John", Lastname = "Doe", Sex = "Male", Temperature = 36.8, HeartRate = 80, Speciality = "general medicine", Age = 44 },
            new Patient {Id = 2, Name = "Jane", Lastname = "Doe", Sex = "Female", Temperature = 36.8, HeartRate = 70, Speciality = "general medicine", Age = 43 },
            new Patient {Id = 3, Name = "Junior", Lastname = "Doe", Sex = "Male", Temperature = 36.8, HeartRate = 90, Speciality = "pediatrics", Age = 8 },
            new Patient {Id = 4, Name = "Mary", Lastname = "Wein", Sex = "Female", Temperature = 36.8, HeartRate = 120, Speciality = "general medicine", Age = 20 },
            new Patient {Id = 5, Name = "Scarlett", Lastname = "Somez", Sex = "Female", Temperature = 36.8, HeartRate = 110, Speciality = "general medicine", Age = 30 },
            new Patient {Id = 6, Name = "Brian", Lastname = "Kid", Sex = "Male", Temperature = 39.8, HeartRate = 80, Speciality = "pediatrics", Age = 11 },
        };

            Console.WriteLine("Pacientes de pediatria menores de 11.");
            Console.WriteLine("==================================================");
            
            var pediatrics = patients.Where(p => p.Speciality == "pediatrics" && p.Age < 11);
            
            foreach (var patient in pediatrics) {
                Console.WriteLine($"Nombre:{patient.Name}, Edad:{patient.Age}");
            }
            Console.WriteLine();

            
            Console.WriteLine("Protocolo de urgencia activado con:");
            Console.WriteLine("==================================================");
            
            var emergency = patients.Where(p=> p.HeartRate > 100 || p.Temperature > 39);
            if (emergency.Count() == 0) {
                Console.WriteLine("Nadie");
            }
            else { 
                foreach (var patient in emergency)
                {
                    Console.WriteLine($"Nombre:{patient.Name}, Temperatura:{patient.Temperature}, Rimo cardiaco:{patient.HeartRate}");
                }
            }
            Console.WriteLine();

            
            Console.WriteLine("Pasamos todos los pacientes de pediatria a medicina general:");
            Console.WriteLine("==================================================");
            
            // Patient list cloned.
            var newPatients = new List<Patient>();
            foreach (var patient in patients) {
                Patient clonedPatient = new Patient();
                clonedPatient.cloneFrom(patient);
                newPatients.Add(clonedPatient);
            }
            
            // We reasign the patients in the cloned list.
            var reasignedPatients = newPatients.Where(p => (p.Speciality == "pediatrics"));
            foreach (var patient in reasignedPatients)
            {
                patient.Speciality = "general medicine";
            }
            foreach (var patient in newPatients)
            {
                Console.WriteLine($"Nombre:{patient.Name}, Edad:{patient.Age}, Especialidad:{patient.Speciality}");
            }
            Console.WriteLine();


            Console.WriteLine("Cuantos pacientes hay en cada especialidad:");
            Console.WriteLine("==================================================");
            
            var patientsPerSpeciality = patients.GroupBy(p => p.Speciality);
            foreach (var item in patientsPerSpeciality)
            {
                Console.WriteLine($"Especialidad:{item.Key}, Total:{item.Count()}");
            }
            Console.WriteLine();


            Console.WriteLine("Muestra si cada paciente tiene o no prioridad:");
            Console.WriteLine("==================================================");
            var priorityList = patients.GroupBy(p => ((p.HeartRate > 100) || (p.Temperature > 39)));
            foreach (var g in priorityList)
            {
                string hasPriority = g.Key ? ("Tiene prioridad") : ("Sin prioridad");
                foreach (var p in g.Select(i => i))
                {
                    Console.WriteLine($"Nombre:{p.Name} {p.Lastname} {hasPriority}");
                }
            }
            Console.WriteLine();



            Console.WriteLine("Edad media de los pacientes en cada especialidad:");
            Console.WriteLine("=================================================");
            var patientsBySpeciality = patients.GroupBy(p => p.Speciality);
            foreach (var speciality in patientsBySpeciality)
            {
                Console.WriteLine($"Especialidad:{speciality.Key} - Edad media {speciality.Average(p => p.Age)}");
            }
            Console.WriteLine();
        }
    }
}
