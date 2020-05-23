using System;
using System.IO;

namespace oopsh6
{
    class Program
    {
        class Arifm
        {
            private double a { get; set; }
            private double b { get; set; }
            private double c { get; set; }
            private double d { get; set; }

            public Arifm()
            {
                Console.WriteLine("You entered no numbers");
            }
            public Arifm(double a, double b, double c, double d)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;
            }
            public void Logs(string err)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Karina\source\repos\oopsh6\logs.txt", true))
                {
                    sw.WriteLine(err);
                }
            }
            public double Calc()
            {
                if(d == 0 || b + c / d - 1 == 0)
                {
                    throw new DivideByZeroException();
                }
                else if((4*b -c) < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    return Math.Log10(4 * b - c) * a / (b + c / d - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            double[] a = {1,0,5,1};        //log()
            //double[] a = {1,0,1,8};      //zero
            //double[] a = {1,0,-10,-2};   //0.25
            Arifm test = new Arifm(a[0],a[1],a[2],a[3]);
            try
            {
                Console.WriteLine(test.Calc());   
            }
            catch (DivideByZeroException ex)
            {
                test.Logs($"Exeption: {ex.Message}, Method:{ex.TargetSite}, {ex.StackTrace}");
            }
            catch (ArgumentException ex)
            {
                test.Logs($"Exeption: {ex.Message}, Method:{ex.TargetSite}, {ex.StackTrace}");
            }
        }
    }
}
