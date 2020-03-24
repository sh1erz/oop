using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop2sh2
{
    class Row
    {
        public string row;
        public Row()
        {
            row = "";
        }
        public Row(string r)
        {
            row = r;
        }
        public int length()
        {
            return row.Length;
        }
        public void set(string r)
        {
            row = r;
        }

        public char this[int index]
        {
            get
            {
                return row[index];
            }
        }
        public string get()
        {
            return row;
        }
    }


    class Text
    {
        public List<Row> text = new List<Row> {};

        public Text(Row r)
        {
            text.Add(r);
        }
        public void append(Row r)
        {
            text.Add(r);
        }

        public void ClearAll()
        {
            text.Clear();
        }

        public void DeleteRow(int row)
        {
            text.RemoveAt(row - 1);
        }
        public void replace(Row r, int i)
        {
            text[i] = r;
        }

        public void Dublicate()
        {
            Console.WriteLine("Enter number of the string you want to find:\n");
            
            int ret = 0;
            int Key = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < text.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < text[i].get().Length; j++)
                {
                    if (text[Key - 1][j] != text[i][j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ret++;
                }
            }
            Console.WriteLine($"Number of similar rows: {ret}\n");
        }

        public void ToUp()
        {
            for (int i = 0; i < text.Count; i++)
            {
                string a = text[i].get();
                Console.WriteLine(a.ToUpper());
            }
        }
        public void DeleteByCount()
        {
            Console.WriteLine("Enter amount of chars in the string you want to delete: ");
            int Key = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < text.Count; i++)
            {
                if(text[i].length() == Key)
                {
                    DeleteRow(i + 1);
                }
            } 
        }
        public void Show()
        {
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < text.Count; i++)
            {
                Console.WriteLine(text[i].get());
            }
            Console.WriteLine("--------------------------------------");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Row first = new Row("Это пример действия программы");
            Row second = new Row("Это пример действия программы");
            Row third = new Row("Эту строка не как те все");
            Row fourth = new Row("И эта");
            Text text = new Text(first);
            text.append(second);
            text.append(third);
            text.append(fourth);
            Console.WriteLine("Рядки:\n");
            text.Show();

            Console.WriteLine("Row to delete: ");
            int Key = Convert.ToInt32(Console.ReadLine());
            text.DeleteRow(Key);
            text.Show();

            text.Dublicate();
            text.Show();

            Console.WriteLine("Text to upper register:\n");
            text.ToUp();

            text.DeleteByCount();
            text.Show();

            Console.WriteLine("Clearing text:\n");
            text.ClearAll();
            text.Show();
        }
    }
}
