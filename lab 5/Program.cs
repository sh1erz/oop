using System;

namespace oop5sh
{
    public class MyString
    {
        protected string row { get; set; }

        public char this[int index]
        {
            get
            {
                return row[index];
            }
        }

        public MyString()
        {
            string row = "0";
        }

        public MyString(string row)
        {
            this.row = row;
        }

        public int MyLength()
        {
            return row.Length;
        }

        public void Print()
        {
            Console.WriteLine($"{row}\n");
        }
    }
    public class SymbolString : MyString
    {
        public SymbolString(string row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (Char.IsDigit(row[i]))
                {
                    throw new ArgumentException("Error: digit is in the row");
                }
            }
            this.row = row;
        }

        public void Switch(char Old, char New)
        {
            this.row = row.Replace(Old, New);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SymbolString wrong = new SymbolString("This is wrong row");
            SymbolString test = new SymbolString("This is the test row");
            Console.Write("Row test: ");
            test.Print();
            Console.WriteLine("Switch 's' to 'i'");
            test.Switch('s', 'i');
            test.Print();
            Console.WriteLine($"Length is: {test.MyLength()}");
        }

    }

}

