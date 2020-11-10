using System;

namespace ST_LW3
{
    class Program
    {
        public static int N = 6;        
        static void Main(string[] args)
        {
            int[,] C = InitC();
            Console.WriteLine("C = C1");
            Print(C);            
            int[,] C1 = InitCn(C);
            Console.WriteLine("C2");
            Print(C1);
            int k = 2;
            if(Equal(C, C1) == false)
            {
                int[,] C2 = InitCn(C1);
                Console.WriteLine($"C{Math.Pow(2, k)}");
                Print(C2);
                while (Equal(C2, C1) == false)
                {
                    k++;
                    C1 = C2;                    
                    C2 = InitCn(C1);
                    Console.WriteLine($"C{Math.Pow(2, k)}");
                    Print(C2);
                }
                C1 = C2;
            }
            Console.WriteLine($"C* = C{Math.Pow(2, k-1)}");
            Print(C1);

            int start, end;
            start = 1;
            end = 2;
            int[] Way = Min(C, C1, start - 1, end - 1);
            Console.WriteLine();
            Console.WriteLine($"Найкоротший шлях з х{start} в x{end} = {C1[start - 1, end - 1]}");
            for(int i=0;i<N;i++)
            {
                if(Way[i]!=0 || i == 0)
                {
                    if (Way[i] != end - 1)
                        Console.Write($"x{Way[i] + 1} -> ");
                    else
                        Console.WriteLine($"x{ Way[i] + 1}");
                }

            }

            
            Console.ReadKey();
        }

        public static int[,] InitCn(int[,] X)
        {
            int[,] C = new int[N, N];
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if(X[i,j]>2)
                    {
                        C[i, j] = Min(X, i, j);
                    }
                    else
                    {
                        C[i, j] = X[i, j];
                    }
                }
            }
            return C;
        }
        public static int[,] InitC()
        {
            int M = 5 * N;
            int[,] C = { { 0, M, 1, M, 1, 4 }, { M, 0, M, 2, 5, 2 }, { 1, M, 0, 2, M, 1 }, { M, 2, 2, 0, M, 3 }, { 1, 5, M, M, 0, 2 }, { 4, 2, 1, 3, 2, 0 } };
            return C;
        }
        public static int Min(int[,] X, int a, int b)
        {
            int min = 5 * N;            
            for (int k = 0; k < N; k++)
            {
                if (min > X[a, k] + X[k, b])
                {
                    min = X[a, k] + X[k, b];
                }
            }
            return min;
        }
        
        public static int[] Min(int[,] X, int[,] Y, int a, int b)
        {
            int j = 1;
            int[] way = new int[N];
            way[0] = a;
            for (int i = 0; i < N; i++)
            {
                if (X[a, i] + Y[i, b] == Y[a, b] && i != a)
                {
                    way[j] = i;
                    j++;
                    a = i;
                }
            }
            while(way[j-1]!=b)
            {
                for (int i = 0; i < N; i++)
                {
                    if (X[a, i] + Y[i, b] == Y[a, b] && i != a)
                    {
                        way[j] = i;
                        j++;
                    }
                }
            }
            return way;                       
        }
        public static void Print(int[,] X)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{X[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static bool Equal(int[,] X, int[,] Y)
        {
            bool equal = true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (X[i, j] != Y[i, j])
                    {
                        equal = false;
                    }

                }
            }
            return equal;
        }
        
    }
}
