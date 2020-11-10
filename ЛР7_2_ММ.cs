using System;

namespace ЛР7_2_ММ
{
    class Program
    {
        public static int N = 10;
        static void Main(string[] args)
        {
            int[,] C = new int[N, N];
            C = InitC();
            Console.WriteLine("C");
            Print(C, N, N);
            Console.WriteLine();
            bool[] I = new bool[N];
            int start = 1;
            int end = 2;
            int[,] min = new int[N, 2];
            I[start - 1] = true;            
            min[start - 1, 0] = 0;
            min[start - 1, 1] = 0;
            int[] t = Min(C, min, I);
            min[t[0]-1, 0] = t[1];
            min[t[0]-1, 1] = t[2];
            I[t[0] - 1] = true;                        
            while (Check(I) == false)
            {
                t = Min(C, min, I);
                min[t[0] - 1, 0] = t[1];
                min[t[0] - 1, 1] = t[2];
                I[t[0] - 1] = true;                                
            }
            Console.WriteLine("n h (мiнiмальний шлях(h), попередня вершина(n))");
            Print(min, N, 2);

            int[] Way = new int[N];
            int temp = end - 1;
            for(int i=0;i<N;i++)
            {
                if (i == 0)
                    Way[i] = end;
                else if (min[temp, 0] == start)
                {
                    Way[i] = start;
                    break;
                }
                else
                {
                    Way[i] = min[temp, 0];
                    temp = min[temp, 0] - 1;
                }
            }
            Console.WriteLine();
            Print(Way, N);
            Console.WriteLine($"h = {min[end - 1, 1]}");
            Console.ReadKey();
        }

        public static bool Check(bool[] I)
        {
            bool check = true;
            for (int i = 0; i < N; i++)
            {
                if (I[i] == false)
                    check = false;
            }
            return check;
        }
        public static int[] Min(int[,] C, int[,] min, bool[] I)
        {
            int[,] h = new int[N, N];
            int[] temp = new int[3];
            temp[1] = 0;
            for(int i=0;i<N;i++)
            {
                if(I[i]==true)
                {                    
                    for(int j=0;j<N;j++)
                    {
                        if(I[j]==false && C[i, j] > 0)
                        {
                            h[i, j] = min[i, 1] + C[i, j];                           
                            if(temp[2]>h[i,j] || temp[2] == 0)
                            {
                                temp[0] = j + 1;
                                temp[1] = i + 1;
                                temp[2] = h[i, j];
                            }
                            
                        }
                    }
                }
            }            
            return temp;
        }
        public static int[,] InitC()
        {
            int[,] C = new int[N, N];
            C[0, 5] = 2;
            C[0, 6] = 3;
            C[0, 7] = 1;
            C[0, 8] = 5;
            C[2, 1] = 5;
            C[3, 1] = 4;
            C[3, 4] = 1;
            C[4, 1] = 4;
            C[5, 3] = 3;
            C[5, 4] = 2;
            C[5, 6] = 5;
            C[5, 9] = 1;
            C[6, 1] = 6;
            C[6, 2] = 2;
            C[6, 4] = 1;
            C[6, 8] = 1;
            C[7, 6] = 2;
            C[8, 5] = 2;
            C[9, 3] = 2;
            return C;
        }
        public static void Print(int[,] X, int m, int n)
        {
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    Console.Write($"{X[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void Print(int[] X, int n)
        {
            for (int i = n-1; i >= 0; i--)
            {        
                if(X[i] != 0)
                    Console.Write($"x{X[i]} -> ");                               
            }
        }
    }
}
