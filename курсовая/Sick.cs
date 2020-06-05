using System;
using System.Collections.Generic;

namespace kursach
{
    public class Sick : Program.Person
        {

            public MedCard MyMedCard { get; private set; }

            public Sick(string name)
                : base(name)
            {
                MyMedCard = new MedCard();
            }

            public override void ShowInfo()
            {
                Console.WriteLine($"Name: {Name}\n");
            }

            public Doctor FindDoctor(string spec)
            {
                foreach (var doctor in Doctor.Doctors)
                {
                    if (doctor.Spec == spec)
                    {
                        OnEvent("Doctor found");
                        return doctor;
                    }
                }
                OnEvent("Doctor not found");
                return null;
            }

            public void Regist(Doctor doctor, int day)
            {
                doctor.MySchedule.ShowSchedule(day);
                Console.Write("Enter time of your visit\nHours: ");
                int timeH = Convert.ToInt32(Console.ReadLine());
                Console.Write("minutes: ");
                int timeM = Convert.ToInt32(Console.ReadLine());
                if (doctor.MySchedule.Regist(day, timeH, timeM))
                {
                    OnEvent($"You are successfully registered, {Name}");
                }
                else
                {
                    OnEvent($"Something went wrong...");
                }
            }
        }
}