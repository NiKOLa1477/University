using System;

namespace ЛР6_ММ
{
    class Program
    {
        static void Main(string[] args)
        {
            double alpha, beta, c, b, tau;
            int n;
            alpha = 0.5;
            beta = 0.5;
            c = 0.023;
            b = 0.007;
            n = 14;
            tau = 0.1;
            int[] M = new int[n];
            int[] N = new int[n];
            N[0] = 135;
            M[0] = 203;
            for(int i =1;i<n;i++)
            {
                N[i] = (int)(N[i - 1] / (1 - tau * (alpha - c * M[i - 1])));
                M[i] = (int)(M[i - 1] / (1 - tau * (-beta + b * N[i - 1])));
            }
            Console.WriteLine("N  |  M");
            for(int i=0;i<n;i++)
            {
                Console.WriteLine($"{N[i]} | {M[i]}");
            }
            Console.ReadKey();
        }
    }
}
