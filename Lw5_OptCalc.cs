using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static int count;
        static bool check = false;
        static bool rand = false;
        static Matrix b;
        static Matrix C2;
        static Matrix A;
        static Matrix A1;
        static Matrix A2;
        static Matrix B2;
        static Matrix b1;
        static Matrix c1;
        static Matrix y1;
        static Matrix y2;
        static Matrix Y3;
        static Matrix Ans1;
        static Matrix Ans2;
        static Matrix Ans3;
        static Matrix Result;

        static AutoResetEvent chy1 = new AutoResetEvent(false);
        static AutoResetEvent chy2 = new AutoResetEvent(false);
        static AutoResetEvent chY3 = new AutoResetEvent(false);
        static AutoResetEvent chY32 = new AutoResetEvent(false);
        static AutoResetEvent chans1 = new AutoResetEvent(false);
        static AutoResetEvent chans2 = new AutoResetEvent(false);
        static AutoResetEvent chans3 = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            while (!check)
            {
                try
                {
                    Console.WriteLine("Enter size of arrays");
                    count = int.Parse(Console.ReadLine());
                    check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error. {ex.Message}");
                    check = false;
                }
            }
            A = new Matrix(count, "A");
            A1 = new Matrix(count, "A1");
            A2 = new Matrix(count, "A2");
            B2 = new Matrix(count, "B2");
            b1 = new Matrix(count, "b1", "vector");
            c1 = new Matrix(count, "c1", "vector");
            Console.WriteLine("Do you want set random values? Y/N");
            switch (Console.ReadLine())
            {
                case "Y":
                    rand = true;
                    break;
                case "N":
                    A.InitValues();
                    A1.InitValues();
                    A2.InitValues();
                    B2.InitValues();
                    b1.InitValues();
                    c1.InitValues();
                    break;
                default:
                    A.DefaultInit();
                    A1.DefaultInit();
                    A2.DefaultInit();
                    B2.DefaultInit();
                    b1.DefaultInit();
                    c1.DefaultInit();
                    break;
            }
            Task t1 = new Task(T1);
            t1.Start();
            Task t2 = new Task(T2);
            t2.Start();
            Task t3 = new Task(T3);
            t3.Start();

            Result = new Matrix(count, "Result");
            chans1.WaitOne();
            chans2.WaitOne();
            Result = Ans1 - Ans2;
            chans3.WaitOne();
            Result = Result + Ans3;
            Console.WriteLine("Result calculated");

            double k1 = 1;
            double k2 = 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 1; j < count; j++)
                {
                    while (Result.elements[i, j] * k1 > 1000)
                    {
                        k1 = k1 / 10;
                    }
                }
            }
            Result = Result * k1;
            for (int i = 0; i < count; i++)
            {
                while (Result.elements[i, 0] * k2 > 1000)
                {
                    k2 = k2 / 10;
                }
            }
            for (int i = 0; i < count; i++)
            {
                Result.elements[i, 0] = Result.elements[i, 0] * k2;
            }
            Result.Print();
            Console.ReadKey();
        }

        public static void T1()
        {
            b = new Matrix(count, "b");
            b.Init_b();
            if (rand == true)
            {
                A.RandomInit();
            }
            y1 = new Matrix(count, "y1");
            y1 = A * b;
            Console.WriteLine("y1 calculated");
            chy1.Set();
            chY3.WaitOne();
            Ans2 = (y1 * y1) * Y3;
            Console.WriteLine("Ans2 calculated");
            chans2.Set();
        }
        public static void T2()
        {
            C2 = new Matrix(count, "C2");
            C2.Init_C2();
            if (rand == true)
            {
                A2.RandomInit();
                B2.RandomInit();
            }
            Y3 = new Matrix(count, "Y3");
            Y3 = A2 * (B2 + C2);
            Console.WriteLine("Y3 calculated");
            chY3.Set();
            chY32.Set();
            chy2.WaitOne();
            Ans1 = Y3 * y2 + Y3 * Y3 * Y3;
            Console.WriteLine("Ans1 calculated");
            chans1.Set();
        }
        public static void T3()
        {
            if (rand == true)
            {
                A1.RandomInit();
                b1.RandomInit();
                c1.RandomInit();
            }
            y2 = new Matrix(count, "y2");
            y2 = A1 * (b1 + (c1 * 4.0));
            Console.WriteLine("y2 calculated");
            chy2.Set();
            chy1.WaitOne();
            chY32.WaitOne();
            Ans3 = y2 * y1 + Y3 * Y3 * y1;
            Console.WriteLine("Ans3 calculated");
            chans3.Set();
        }

        public class Matrix
        {
            public static int n;
            public double[,] elements;
            public string type;
            public string name;

            public Matrix(int count)
            {
                n = count;
                elements = new double[n, n];
            }

            public Matrix(int count, string name) : this(count)
            {
                this.name = name;
            }

            public Matrix(int count, string name, string t) : this(count, name)
            {
                type = t;
            }

            public static Matrix operator +(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Z.elements[i, j] = X.elements[i, j] + Y.elements[i, j];
                    }
                }
                return Z;
            }

            public static Matrix operator -(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Z.elements[i, j] = X.elements[i, j] - Y.elements[i, j];
                    }
                }
                return Z;
            }

            public static Matrix operator *(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(n);
                if (X.elements[0, 1] != 0)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Z.elements[i, k] = 0;
                            for (int j = 0; j < n; j++)
                            {
                                Z.elements[i, k] = Z.elements[i, k] + X.elements[i, j] * Y.elements[j, k];
                            }
                        }
                    }
                }
                else if (X.elements[1, 0] == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Z.elements[i, j] = X.elements[0, 0] * Y.elements[i, j];
                        }
                    }
                }
                else
                {
                    Z.elements[0, 0] = 0;
                    for (int i = 0; i < n; i++)
                    {
                        Z.elements[0, 0] = Z.elements[0, 0] + X.elements[i, 0] * Y.elements[i, 0];
                    }
                }
                return Z;
            }

            public static Matrix operator *(Matrix X, double k)
            {
                Matrix Z = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Z.elements[i, j] = X.elements[i, j] * k;
                    }
                }
                return Z;
            }

            public void InitValues()
            {
                check = false;
                while (!check)
                {
                    try
                    {
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (type != "vector")
                                {
                                initm:
                                    Console.Write($"Enter {name}[{i + 1}][{j + 1}]=");
                                    elements[i, j] = int.Parse(Console.ReadLine());
                                    if (elements[i, j] <= 0)
                                    {
                                        Console.WriteLine("Error. Value is less than or equal zero");
                                        goto initm;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                    initv:
                                        Console.Write($"Enter {name}[{i + 1}][{j + 1}]=");
                                        elements[i, j] = int.Parse(Console.ReadLine());
                                        if (elements[i, j] <= 0)
                                        {
                                            Console.WriteLine("Error. Value is less than or equal zero");
                                            goto initv;
                                        }
                                    }
                                    else
                                        elements[i, j] = 0;
                                }
                            }
                        }
                        Console.WriteLine("");
                        check = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error. {ex.Message}");
                        check = false;
                    }
                }
            }

            public void DefaultInit()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (type != "vector")
                        {
                            elements[i, j] = 1;
                        }
                        else
                        {
                            if (j == 0)
                            {
                                elements[i, j] = 9;
                            }
                            else
                                elements[i, j] = 0;
                        }
                    }
                }
            }

            public void RandomInit()
            {
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (type != "vector")
                        {
                            elements[i, j] = rand.Next(1, 140);
                        }
                        else
                        {
                            if (j == 0)
                            {
                                elements[i, j] = rand.Next(1, 140);
                            }
                            else
                                elements[i, j] = 0;
                        }
                    }
                }
            }

            public void Init_b()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j == 0)
                        {
                            elements[i, j] = 4.0 / (Math.Pow(i + 1, 3) + 3);
                        }
                        else
                            elements[i, j] = 0;
                    }
                }
            }

            public void Init_C2()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        elements[i, j] = 1.0 / (i + 1 + Math.Pow(j + 1, 2));
                    }
                }
            }

            public void Print()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (n > 4)
                            Console.WriteLine($"Result[{i + 1}][{j + 1}]={elements[i, j]}");
                        else
                            Console.Write($"{elements[i, j]} ");
                    }
                    if (n < 5)
                        Console.WriteLine("");
                }
            }
        }
    }
}