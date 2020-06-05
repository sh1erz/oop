using System;
using System.Collections.Generic;

namespace kursach
{
    public class Sick : Program.Person
        {
            public class MedCard
            {
                private List<string> date { get; set; }
                private List<string> time { get; set; }
                private List<string> illness { get; set; }

                public void Add(string Date, string Time, string Illness)
                {
                    if (date == null)
                    {
                        date = new List<string>();
                        time = new List<string>();
                        illness = new List<string>();
                    }

                    date.Add(Date);
                    time.Add(Time);
                    illness.Add(Illness);
                }

                public void ShowMedCard()
                {
                    for (int i = 0; i < date.Count; i++)
                    {
                        Console.WriteLine($"Date: {date[i]}  time: {time[i]}  illness: {illness[i]}");
                    }
                }

                public void ShowMedCard(string Date)
                {
                    int ind = date.IndexOf(Date);
                    if (ind == -1)
                    {
                        Console.WriteLine("Date not found");
                    }
                    else
                    {
                        Console.WriteLine($"Date: {date[ind]}  time: {time[ind]}  illness: {illness[ind]}");   
                    }
                }
            }

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