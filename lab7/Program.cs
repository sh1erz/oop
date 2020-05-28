using System;

namespace ConsoleApp1
{
    class Program
    {
        class Double
        {
            class DoubleNode
            {
                public double Data { get; private set; }
                private DoubleNode PrevNode { get; set; }
                private DoubleNode NextNode;

                public DoubleNode GetNext
                {
                    get { return NextNode; }
                    set { NextNode = value; }
                }

                public DoubleNode GetPrev
                {
                    get { return PrevNode; }
                    set { PrevNode = value; }
                }

                public DoubleNode(double data, DoubleNode prevNode = null, DoubleNode nextNode = null)
                {
                    Data = data;
                    PrevNode = prevNode;
                    NextNode = nextNode;
                }
            }

            private DoubleNode head;
            private DoubleNode tail;
            private static int size { get; set; }

            public Double()
            {
                size = 0;
                head = null;
                tail = null;
            }

            public void Add(double data)
            {
                if (head == null)
                {
                    head = new DoubleNode(data);
                    tail = head;
                    size++;
                }
                else
                {
                    DoubleNode node = new DoubleNode(data);
                    DoubleNode temp = head;
                    node.GetNext = temp;
                    head = node;
                    temp.GetPrev = node;
                    size++;
                }
            }

            public bool RemoveInd(int ind)
            {
                if (ind > size)
                {
                    return false;
                }

                DoubleNode curr;
                if (ind < size / 2)
                {
                    curr = head;
                    int i = 0;
                    while (i != ind)
                    {
                        curr = curr.GetNext;
                        i++;
                    }
                }
                else
                {
                    curr = tail;
                    int i = size - 1;
                    while (i != ind)
                    {
                        curr = curr.GetPrev;
                        i--;
                    }
                }

                if (curr.GetNext != null)
                {
                    curr.GetNext.GetPrev = curr.GetPrev;
                }
                else
                {
                    tail = curr.GetPrev;
                }

                if (curr.GetPrev != null)
                {
                    curr.GetPrev.GetNext = curr.GetNext;
                }
                else
                {
                    head = curr.GetNext;
                }

                size--;
                return true;
            }

            public int LessThanAverage()
            {
                DoubleNode temp = head;
                double arifsum = temp.Data;
                while (head != null)
                {
                    if (temp.GetNext != null)
                    {
                        temp = temp.GetNext;
                        arifsum += temp.Data;
                    }
                    else
                    {
                        break;
                    }
                }

                arifsum /= size;
                temp = head;
                int sum = 0;
                for (int i = 0; i < size; i++)
                {
                    if (temp.Data < arifsum)
                    {
                        sum++;
                    }

                    temp = temp.GetNext;
                }

                return sum;
            }

            public double MaxElement()
            {
                if (head == null)
                {
                    Console.WriteLine("head == null");
                    return 0;
                }

                DoubleNode temp = head;
                double maxim = head.Data;
                for (int i = 1; i < size; i++)
                {
                    temp = temp.GetNext;
                    if (temp.Data > maxim)
                    {
                        maxim = temp.Data;
                    }
                }

                return maxim;
            }

            public int FindIndex(double data)
            {
                DoubleNode temp = head;
                int ind = 0;
                while (temp.Data != data)
                {
                    temp = temp.GetNext;
                    ind++;
                    if (ind >= size)
                    {
                        Console.WriteLine("Element does not exist");
                        return 0;
                    }
                }

                return ind;
            }

            public void DeleteAfterIndex(int ind)
            {
                for (int i = size - 1; i > ind; i--)
                {
                    RemoveInd(i);
                }
            }

            public void Print()
            {
                DoubleNode temp = head;
                while (head != null)
                {
                    Console.Write($"{temp.Data} ");
                    if (temp.GetNext != null)
                    {
                        temp = temp.GetNext;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Double test = new Double();
            test.Add((4));
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Print();

            double max = test.MaxElement();
            Console.WriteLine($"Max element: {max}");
            int index = test.FindIndex(max);
            Console.WriteLine($"Index of max element: {index}");
            test.DeleteAfterIndex(index);
            Console.WriteLine("Deleting elements after max element");
            test.Print();
            Console.WriteLine($"Number of elements less than average: {test.LessThanAverage()}");
            test.RemoveInd(3);
            Console.WriteLine("After removing element by index");
            test.Print();
        }
    }
}