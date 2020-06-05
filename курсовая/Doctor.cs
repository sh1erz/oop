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


            public class Schedule
            {
                private readonly List<double>[] WorkingHours = new List<double>[5];

                public Schedule(int startH, int startM, int endH, int endM, int duration)
                {
                    try
                    {
                        if (startH < 0 || startM < 0 || endH < 0 || endM < 0 || duration < 0)
                        {
                            throw new ArgumentException();
                        }

                        int allMinutes = (endH * 60 + endM) - (startH * 60 + startM); //общее время приема
                        for (int i = 0; i < WorkingHours.Length; i++)
                        {
                            WorkingHours[i] = new List<double> {startH * 60 + startM}; //for each day add start minutes
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 1; j < allMinutes / duration; j++)
                            {
                                WorkingHours[i].Add(WorkingHours[i][j - 1] + duration); //add vozmojni okna
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Program.Logs(ex);
                    }
                }

                public bool Exist()
                {
                    if (WorkingHours[0] != null)
                    {
                        return true;
                    }

                    return false;
                }
                
                public void ShowSchedule(int day)
                {
                    try
                    {
                        if (day > 5 || day < 1)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Program.Logs(ex);
                    }
                    Console.WriteLine($"Day: {day}");
                    for (int i = 0; i < WorkingHours[day - 1].Count; i++)
                    {
                        double hours = WorkingHours[day - 1][i] / 60;
                        hours = Math.Floor(hours);
                        double minutes = (WorkingHours[day - 1][i] / 60 - hours) * 0.6;
                        minutes = Math.Round(minutes, 2) * 100;
                        Console.Write($"{hours}:{minutes} ");
                    }

                    Console.WriteLine();
                }

                public void ShowSchedule()
                {
                    Console.WriteLine("Day 1:\t");
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < WorkingHours[i].Count; j++)
                        {
                            double hours = WorkingHours[i][j] / 60;
                            hours = Math.Floor(hours);
                            double minutes = (WorkingHours[i][j] / 60 - hours) * 0.6;
                            minutes = Math.Round(minutes, 2) * 100;
                            Console.Write($"{hours}:{minutes} ");
                        }

                        Console.WriteLine($"\nDay {i + 2}:\t");
                    }

                    Console.WriteLine("holiday");
                }

                public bool Regist(int day, int timeH, int timeM)
                {
                    try
                    {
                        if (day > 5 || day < 1 || timeH < 0 || timeM < 0 || timeH > 24 || timeM > 60)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Program.Logs(ex);
                        return false;
                    }

                    int time = timeH * 60 + timeM;
                    int index = WorkingHours[day - 1].IndexOf(time);
                    if (WorkingHours[day - 1][index] != -1)
                    {
                        WorkingHours[day - 1][index] = -1; //person had assigned so some useless value 
                        return true;
                    }

                    return false;
                }
            }
        }

}