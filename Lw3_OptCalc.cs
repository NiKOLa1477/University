using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int n, t;
        public static int[,] A;
        public static int[,] B;
        public static int[,,] C;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("A:");
            A = new int[n, n];
            A = InitA(n);
            Print(A, n);
            Console.WriteLine("B:");
            B = new int[n, n];
            B = InitB(n);
            Print(B, n);
            Console.WriteLine("");
            Alg1(n);
            Console.WriteLine("");
            Alg2(n);
            Console.ReadKey();
        }

        public static void Alg1(int size)
        {
            int[,,] Z = new int[size, size, size + 1];
            t = 0;
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    Z[i, j, 0] = 0;
                    for(int k=0;k<size;k++)
                    {
                        Z[i, j, k + 1] = Z[i, j, k] + A[i, k] * B[k, j];
                        t += 2;
                    }      
                }
            }

            Console.WriteLine("Odnorazove");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{Z[i, j, size]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Operations equal {t}");
        }

        public static void Alg2(int size)
        {
            t = 0;
            C = new int[size, size, size + 1];
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    C[i, j, 0] = 0;     
                }
            }
            LocRec(0, 0, 0);

            Console.WriteLine("LocalRecursive");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{C[i, j, size]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Operations equal {t}");
        }

        public static void LocRec(int i, int j, int k)
        {
            int size = A.GetLength(0);

            if (k < n && i < n && j  <n)
            {
                if(A[i,k] != 0 && B[k,j] != 0)
                {
                    C[i, j, n] += A[i, k] * B[k, j];
                    t++;
                }

                LocRec(i, j, k + 1);
                if(k == n - 1)
                {
                    k = 0;
                    LocRec(i, j + 1, k);
                    if(j == n - 1)
                    {
                        j = 0;
                        LocRec(i + 1, j, k);
                    }
                }
            }
        }

        public static int[,] InitA(int size)
        {
            int[,] T = new int[size, size];
            int t1, t2;
            for(int i=0;i<size;i++)
            {
                t1 = size - 2 * i;
                if (t1 <= 0)
                    t2 = Math.Abs(size - 2 * i - 2);
                else
                    t2 = t1;
                for(int j=0;j<size;j++)
                {
                    if (j >= (size - t2) / 2 && j < (size + t2) / 2)
                        T[i, j] = 1;
                    else
                        T[i, j] = 0;
                }
            }
            return T;
        }

        public static int[,] InitB(int size)
        {
            Random rand = new Random();
            int[,] T = new int[size, size];
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    if (i >= j)
                        T[i, j] = rand.Next(1, 100);
                    else
                        T[i, j] = 0;
                }
            }
            return T;
        }

        public static void Print(int[,] M, int size )
        {
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    Console.Write($"{M[i,j]} ");
                }
                Console.WriteLine("");
            }
        }
    }
}
