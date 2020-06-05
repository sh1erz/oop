using System;
using System.Collections.Generic;
namespace kursach
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
}