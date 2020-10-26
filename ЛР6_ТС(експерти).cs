using System;

namespace ST_LW6
{
    class Program
    {
        static int m = 7;
        static int n = 6;
        static void Main(string[] args)
        {
            double[] VagAv = new double[n];
            double[] VagMed = new double[n];
            double[,] T = new double[m, n];
            T = InitT();
            Print(T);
            double[] SC = SumCol(T);
            Console.WriteLine("Метод сер. ар. рангiв");
            Console.WriteLine("Сума рангiв");
            Print(SC, n);
            for (int i = 0; i<n;i++)
            {
                SC[i] /= m;
            }
            Console.WriteLine("Сер. ар. ранг");
            Print(SC, n);
            double[] AvS = AvSum(SC, n);
            Console.WriteLine("Пiдсумковий ранг за сер. ар.");
            Print(AvS, n);
            Console.WriteLine("Ваги за сер. ар.");
            VagAv = GetVag(AvS, n);
            Print(VagAv, n);
            Console.WriteLine($"Сума ваг = {Sum(VagAv, n)}");
            Console.WriteLine("Метод медiан рангiв");
            double[] Med = GetMed(T);
            Console.WriteLine("Медiани рангiв");
            Print(Med, n);
            Med = AvSum(Med, n);
            Console.WriteLine("Пiдсумковий ранг за медiанами");
            Print(Med, n);
            VagMed = GetVag(Med, n);
            Console.WriteLine("Ваги за медiанами");
            Print(VagMed, n);
            Console.WriteLine($"Сума ваг = {Sum(VagMed, n)}");
            double a = Math.Pow(m, 2) * (Math.Pow(n, 3) - n);
            double b = (m * (n + 1)) / 2;
            SC = SumCol(T);
            double S = 0;
            for(int i =0;i<n;i++)
            {
                S += Math.Pow(SC[i] - b, 2);
            }
            double[] H = GetH(T);            
            double[] Tj = new double[m];
            for (int i = 0; i < m; i++)
            {
                double sum = 0;
                for (int j = 0; j < H[i]; j++)
                {
                    sum += Math.Pow(2, 3) - 2;
                }
                Tj[i] = sum;
            }            
            double SumT = Sum(Tj, m);            
            double W = 12 / (a - m * SumT) * S;
            Console.WriteLine($"W = {W}");
            double Xf = m * (n - 1) * W;
            Console.WriteLine($"Xф = {Xf}");
            double Xk = 16.75;
            Console.WriteLine($"Хк = {Xk} (при alpha = 0.005)");
            if(Xf>Xk)
                Console.WriteLine("Ранговий зв'язок мiж думками експертiв значущий, коефiцiєнту конкордацiї можна довiряти i отриманi на його основi висновки справедливi.");
            else
                Console.WriteLine("Ранговий кореляцiйний зв'язок мiж думками експертiв вiдсутнiй.");
            Console.ReadKey();
        }

        public static double[,] InitT()
        {
            double[,] T = { { 1.5, 5, 1.5, 3, 4, 6 }, { 1, 3, 2, 6, 4, 5 }, { 6, 3, 1, 5, 2, 4 }, { 2, 3, 1, 4.5, 4.5, 6 }, { 1, 2, 5, 6, 4, 3 }, { 2, 3, 1, 5.5, 5.5, 4 }, { 1.5, 3.5, 1.5, 5, 6, 3.5 } };
            return T;
        }
        public static void Print(double[,] T)
        {
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    Console.Write($"{T[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Print(double[] T, int n)
        {
            for (int i = 0; i < n; i++)
            {                
                    Console.Write($"{T[i]} ");                                
            }
            Console.WriteLine();
        }
        public static double[] SumCol(double[,] T)
        {
            double[] S = new double[n];
            for (int j = 0; j < n; j++)
            {
                S[j] = 0;
                for (int i = 0; i < m; i++)
                {
                    S[j] += T[i, j];
                }
                
            }
            return S;
        }
        public static double[] AvSum(double[] S, int n)
        {
            double[] Av = new double[n];
            double max = S[0];
            int j1 = 0;
            int j2 = 0;
            int k = n;
            for(int i=1;i<n;i++)
            {
                if(max<S[i])
                {
                    max = S[i];
                    j1 = i;
                }
                else if(max == S[i])
                {
                    j2 = i;
                }
            }
            if(S[j1]==S[j2] && S[j1]!=0 && j2>0)
            {
                Av[j1] = k - 0.5;
                Av[j2] = k - 0.5;
                S[j1] = 0;
                S[j2] = 0;
                k -= 2;
            }
            else
            {
                Av[j1] = k;                
                S[j1] = 0;                
                k--;
            }
            while(k>0)
            {
                max = S[0];
                j1 = 0;
                j2 = 0;
                for (int i = 1; i < n; i++)
                {
                    if (max < S[i])
                    {
                        max = S[i];
                        j1 = i;
                    }
                    else if (max == S[i])
                    {
                        j2 = i;
                    }
                }
                if (S[j1] == S[j2] && S[j1] != 0 && j2 > 0)
                {
                    Av[j1] = k - 0.5;
                    Av[j2] = k - 0.5;
                    S[j1] = 0;
                    S[j2] = 0;
                    k -= 2;
                }
                else
                {
                    Av[j1] = k;
                    S[j1] = 0;
                    k--;
                }
            }
            return Av;

        }
        public static double[] GetMed(double[,] T)
        {
            double[] Med = new double[n];
            double[] Col = new double[m];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    Col[i] = T[i, j];
                }
                Col = Sort(Col, m);
                //Console.WriteLine($"{j+1} сортований стовбець");
                //Print(Col, m);
                //Console.WriteLine();
                Med[j] = Col[(m / 2 + m % 2) - 1];
            }
            
            return Med;
        }
        public static double[] Sort(double[] M, int n)
        {
            double temp;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (M[i] >= M[j])
                    {
                        temp = M[i];
                        M[i] = M[j];
                        M[j] = temp;
                    }
                }
            }
            return M;
        }
        public static double[] GetVag(double[] M, int n)
        {
            double S = 0;
            for(int i=0;i<n;i++)
            {
                S += M[i];
            }
            for(int i=0;i<n;i++)
            {
                M[i] /= S;
            }
            return M;
        }
        public static double Sum(double[] M, int n)
        {
            double S = 0;
            for(int i=0;i<n;i++)
            {
                S += M[i];
            }
            return S;
        }
        public static double[] GetH(double[,] M)
        {
            double[] H = new double[m];
            for(int k=0;k<m;k++)
            {
                int h = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (M[k,i] == M[k,j])
                        {
                            h++;
                        }
                    }
                }
                H[k] = h;
            }
            return H;
        }
    }
}
