using System;

namespace csh
{
    public class Vidriz
    {
        public int[] vidr = new int[4];

        public Vidriz()
        {
            vidr = new int[4] { 0, 0, 0, 0 };
        }

        public Vidriz(int x1, int y1, int x2, int y2) 
        {
            vidr = new int[4] { x1, y1, x2, y2 };
        }
        public Vidriz(Vidriz priv)
        {
            for (int i = 0; i < 4; i++)
            {
                this.vidr[i] = priv.vidr[i];
            }
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(vidr[0] - vidr[2], 2) + Math.Pow(vidr[3] - vidr[1], 2));
        }

        public void Print()
        {
            for (int i = 0; i < 4; i++)
            {
                if(i % 2 == 0)
                {
                    Console.Write($"x = {vidr[i]}\t");
                }
                else
                {
                    Console.WriteLine($"y = {vidr[i]}");
                }
            }
            Console.WriteLine("\n");
        }

        public static Vidriz operator +(Vidriz V1, Vidriz V2)
        {
            Vidriz sum = new Vidriz();
            for (int i = 0; i < 4; i++)
            {
                sum.vidr[i] = V1.vidr[i] + V2.vidr[i];
            }
            return sum;
        }

        public static Vidriz operator *(Vidriz V1, int k)
        {
            Vidriz mult = new Vidriz();
            for (int i = 0; i < 4; i++)
            {
                mult.vidr[i] = V1.vidr[i] * k;
            }
            return mult;
        }

        public void Info()
        {
            Print();
            double a = Length();
            Console.WriteLine($"Длинна отрезка: {a}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание L1 с конструктором по умолчанию");
            Vidriz L1 = new Vidriz();
            L1.Print();
            Console.WriteLine("Создание L2 с конструктором с параметрами");
            Vidriz L2 = new Vidriz(1,1,2,1);
            L2.Print();
            Console.WriteLine("Создание L3 с конструктором копирования");
            Vidriz L3 = new Vidriz(L2);
            L3.Print();
            Console.WriteLine("Умножение L3 на 2");
            L3 *= 2;
            L3.Print();
            Console.WriteLine("L1 = L2 + L3");
            L1 = L2 + L3;
            L1.Print();
            Console.WriteLine("Получение данных о L3");
            L3.Info();
        }
    }
}
