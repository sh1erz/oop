using System;
using System.Collections.Generic;

namespace kursach
{
    public class Doctor : Program.Person
    {
        public static List<Doctor> Doctors { get; private set; } //list of doctors
        public string Spec { get; }
        public Schedule MySchedule { get; private set; }

        public Doctor(string name, string specialization)
            : base(name)
        {
            Doctors ??= new List<Doctor>();
            Spec = specialization;
            Doctors.Add(this);
        }

        public void CreateMySchedule(int startH, int startM, int endH, int endM, int duration)
        {
            MySchedule = new Schedule(startH, startM, endH, endM, duration);
        }

        public void WriteToMedCard(Sick patient, string illness, string date, string time)
        {
            patient.MyMedCard.Add(date, time, illness);
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}\nSpecialization: {Spec}");
        }
    }
}

