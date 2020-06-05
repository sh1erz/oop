using System;
using System.Collections.Generic;
using System.IO;

namespace kursach
{
    public class Program
    {
        public static void Logs(Exception ex)
        {
            string err = $"Exception: {ex.Message}, Method:{ex.TargetSite}, {ex.StackTrace}";
            using StreamWriter sw = new StreamWriter(@"C:\Users\Karina\RiderProjects\kursach\kursach\logs.txt", true);
            sw.WriteLine(ex);
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        public abstract class Person
        {
            public event AccountHandler Notify;

            public delegate void AccountHandler(string message);

            protected void OnEvent(string message)
            {
                Notify?.Invoke(message);
            }

            protected string Name { get; }

            protected Person(string name)
            {
                Name = name;
            }

            public abstract void ShowInfo();
        }
        

        static void Main(string[] args)
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Sick> sicks = new List<Sick>();
            while (true)
            {
                Console.WriteLine("For doctors - 1, for patients - 2");
                int inp = Convert.ToInt32(Console.ReadLine());
                if (inp == 1)
                {
                    Console.WriteLine(
                        "Choose an option:\ncreate doctor acc - 1\ncreate schedule - 2\nadd to med card - 3\nshow patient med card - 4\nshow schedule - 5");
                    inp = Convert.ToInt32(Console.ReadLine());
                    switch (inp)
                    {
                        case 1: //create doctor
                            Console.Write("Enter your name: ");
                            string name = Console.ReadLine();
                            Console.Write("Specialisation: ");
                            string spec = Console.ReadLine();
                            doctors.Add(new Doctor(name, spec));
                            Console.WriteLine($"Your index is: {doctors.Count - 1}");
                            doctors[^1].ShowInfo();
                            doctors[^1].Notify += DisplayMessage;
                            break;
                        case 2: //create schedule
                            Console.Write("Enter your doctor`s index: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind >= doctors.Count)
                            {
                                break;
                            }
                            int startH, startM, endH, endM, duration;
                            Console.Write("Start hours: ");
                            startH = Convert.ToInt32(Console.ReadLine());
                            Console.Write("minutes: ");
                            startM = Convert.ToInt32(Console.ReadLine());
                            Console.Write("End hours: ");
                            endH = Convert.ToInt32(Console.ReadLine());
                            Console.Write("minutes: ");
                            endM = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Duration of one visit: ");
                            duration = Convert.ToInt32(Console.ReadLine());
                            doctors[ind].CreateMySchedule(startH, startM, endH, endM, duration);
                            if (doctors[ind].MySchedule.Exist())
                            {
                                doctors[ind].MySchedule.ShowSchedule(); 
                            }
                            break;
                        case 3: //add to med card
                            Console.Write("Enter your doctor`s index: ");
                            ind = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter your patient`s index: ");
                            int indp = Convert.ToInt32(Console.ReadLine());
                            if (ind >= doctors.Count || indp >= sicks.Count)
                            {
                                break;
                            }
                            Console.Write("Date: ");
                            string date = Console.ReadLine();
                            Console.Write("Time: ");
                            string time = Console.ReadLine();
                            Console.Write("Illness: ");
                            string illness = Console.ReadLine();
                            doctors[ind].WriteToMedCard(sicks[indp], illness, date, time);
                            break;
                        case 4: //show patient med card
                            Console.Write("Enter your patient`s index: ");
                            indp = Convert.ToInt32(Console.ReadLine());
                            if (indp >= sicks.Count)
                            {
                                break;
                            }
                            Console.WriteLine("If you searching by date - enter it, else print 0");
                            date = Console.ReadLine();
                            if (date == "0")
                            {
                                sicks[indp].MyMedCard?.ShowMedCard(); 
                            }
                            else
                            {
                                sicks[indp].MyMedCard?.ShowMedCard(date);
                            }
                            
                            break;
                        case 5: //show schedule
                            Console.Write("Enter your index: ");
                            ind = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Day: ");
                            indp = Convert.ToInt32(Console.ReadLine());
                            doctors[ind].MySchedule?.ShowSchedule(indp);
                            break;
                    }
                }
                else if (inp == 2)
                {
                    Console.WriteLine("Choose an option: \ncreate patient acc - 1\nregister to doctor - 2\n");
                    inp = Convert.ToInt32(Console.ReadLine());
                    switch (inp)
                    {
                        case 1: //create sick person
                            Console.Write("Enter your name: ");
                            string name = Console.ReadLine();
                            sicks.Add(new Sick(name));
                            Console.WriteLine($"Your index is: {sicks.Count - 1}");
                            sicks[^1].ShowInfo();
                            sicks[^1].Notify += DisplayMessage;
                            break;
                        case 2: //register to doctor
                            Console.Write("Enter your patient`s index: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind >= sicks.Count)
                            {
                                break;
                            }
                            Console.Write("Enter doctor specialisation: ");
                            string spec = Console.ReadLine();
                            Doctor doctor = sicks[ind].FindDoctor(spec);
                            if (doctor != null)
                            {
                                Console.Write("Day of the visit: ");
                                int day = Convert.ToInt32(Console.ReadLine());
                                sicks[ind].Regist(doctor, day);
                            }
                            break;
                    }
                }
            }
        }
    }
}