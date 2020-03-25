using System;
using System.Collections.Generic;

namespace oop3sh
{
    class Program
    {
        public class MyMas
        {
            public int[,] Mas;
            public int n;
            public int m;
            private double arifm;

            public MyMas(int row, int col)
            {
                n = row - 1;
                m = col - 1;
                Mas = new int[n, m];
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Mas[i, j] = rnd.Next(1, 10);
                        arifm += Mas[i, j];
                    }
                }
                arifm /= row * col;
            }

            public double Arifm
            {
                get
                {
                    return arifm;
                }
            }

            public void Print()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"{Mas[i,j]}  ");
                    }
                    Console.WriteLine();
                }
            }

            public int this[int index]
            {
                get
                {
                    int dob = 1;
                    if (index >= 0 && index < m)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            dob *= Mas[i, index];
                        }
                        return dob;
                    }

                    else
                    {
                        Console.WriteLine("Wrong index");
                        return 0;
                    }
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Enter amount of rows: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount of columns: ");
                int col = Convert.ToInt32(Console.ReadLine());
                MyMas mas = new MyMas(row, col);
                mas.Print();
                Console.WriteLine("Enter index: ");
                int ind = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Composition: {mas[ind]}\n");
                Console.WriteLine($"Average: {mas.Arifm}\n");
            }
        }
    }
}