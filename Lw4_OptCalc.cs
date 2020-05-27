using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static int K;
        public static int It = 0;
        public static int[,] A;

        private static void Main()
        {
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Enter amount of disks");
                try
                {
                    K = int.Parse(Console.ReadLine());
                    while (K < 3)
                    {
                        Console.WriteLine("Attention! Amount of disks must be more than two.");
                        Console.WriteLine("Enter amount of disks");
                        K = int.Parse(Console.ReadLine());
                    }
                    check = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Error! Enter an integer value.");
                }
            }

            A = new int[K, 3];
            InitA();
            Console.WriteLine("");
            Console.WriteLine("Task");
            PrintA();
            Console.WriteLine("");
            HanoiTowers(K, 0, 1, 2);
            Console.WriteLine("");
            Console.WriteLine("Result");
            PrintA();
            Console.WriteLine("");
            Console.WriteLine($"Operations equal {It}");
            Console.ReadKey();
        }

        public static void PrintA()
        {
            for(int i=0;i<K;i++)
            {
                for(int j=0;j<3;j++)
                    Console.Write($"{A[i,j]} ");
                Console.WriteLine("");
            }
        }

        public static void InitA()
        {
            for (int i = K - 1; i >= 0; i--)
                A[i, 0] = i + 1;
        }

        public static void HanoiTowers(int k, int a, int b, int c)
        {
            if (k > 1) HanoiTowers(k - 1, a, c, b);
            int i, j;
            for(i=0;i<K;i++)
            {
                if (A[i, a] != 0)
                    break;
            }
            for (j = K-1; j >= 0; j--)
            {
                if (A[j, b] == 0)
                    break;
            }
            A[j, b] = A[i, a];
            Console.WriteLine($"Moved disk {A[i, a]} from column {a + 1} to column {b + 1}");
            It++;
            A[i, a] = 0;            
            if (k > 1) HanoiTowers(k - 1, c, b, a);
        }
    }
}
