using System;

namespace ST_LW3
{
    class Program
    {
        public static int N = 5;

        public class Matrix
        {
            public int[,] elements;

            public Matrix()
            {
                elements = new int[2, 2];
            }
            public Matrix(int n)
            {
                elements = new int[n, n];
            }
            public Matrix(int m, int n)
            {
                elements = new int[1, 2];
                elements[0, 0] = m - 1;
                elements[0, 1] = n - 1;
                Console.WriteLine($"Q = (x{m}, x{n})");
            }

            public void InitR1()
            {
                elements[0, 2] = 1;
                elements[0, 3] = 1;
                elements[1, 2] = 1;
                elements[1, 3] = 1;
                elements[2, 0] = 1;
                elements[2, 1] = 1;
                elements[2, 3] = 1;
                elements[2, 4] = 1;
                elements[3, 0] = 1;
                elements[3, 1] = 1;
                elements[3, 2] = 1;
                elements[3, 4] = 1;
                elements[4, 2] = 1;
                elements[4, 3] = 1;
            }
            public void InitR2()
            {
                elements[0, 1] = 1;
                elements[0, 2] = 1;
                elements[0, 4] = 1;
                elements[1, 0] = 1;
                elements[1, 1] = 1;
                elements[1, 4] = 1;
                elements[2, 1] = 1;
                elements[2, 2] = 1;
                elements[3, 1] = 1;
                elements[4, 0] = 1;
                elements[4, 1] = 1;
                elements[4, 2] = 1;
                elements[4, 3] = 1;
                elements[4, 4] = 1;
            }
            public void InitR()
            {
                elements[0, 0] = 1;
                elements[0, 1] = 1;
                elements[0, 3] = 1;
                elements[1, 0] = 1;
                elements[1, 1] = 1;
                elements[1, 2] = 1;
                elements[1, 3] = 1;
                elements[2, 0] = 1;
                elements[2, 2] = 1;
                elements[2, 3] = 1;
                elements[2, 4] = 1;
                elements[3, 1] = 1;
                elements[3, 2] = 1;
                elements[3, 3] = 1;
                elements[3, 4] = 1;
                elements[4, 1] = 1;
                //elements[4, 4] = 1;
            }

            public void Print()
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write($"{elements[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
            public void Print(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"{elements[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }

            public Matrix Con(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(N);
                for(int i=0;i<N;i++)
                {
                    for(int j=0;j<N; j++)
                    {
                        if(X.elements[i,j] == 1 && Y.elements[i,j] == 1)
                        {
                            Z.elements[i, j] = 1;
                        }
                        else
                        {
                            Z.elements[i, j] = 0;
                        }
                    }
                }
                return Z;
            }
            public Matrix Dis(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (X.elements[i, j] == 1 || Y.elements[i, j] == 1)
                        {
                            Z.elements[i, j] = 1;
                        }
                        else
                        {
                            Z.elements[i, j] = 0;
                        }
                    }
                }
                return Z;
            }
            public Matrix Riz(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (X.elements[i, j] == 1 && Y.elements[i, j] == 0)
                        {
                            Z.elements[i, j] = 1;
                        }
                        else
                        {
                            Z.elements[i, j] = 0;
                        }
                    }
                }
                return Z;
            }
            public Matrix SymRiz(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (X.elements[i, j] == Y.elements[i, j])
                        {
                            Z.elements[i, j] = 0;
                        }
                        else
                        {
                            Z.elements[i, j] = 1;
                        }
                    }
                }
                return Z;
            }

            public Matrix Zap(Matrix X)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (X.elements[i, j] == 0)
                        {
                            Z.elements[i, j] = 1;
                        }
                        else
                        {
                            Z.elements[i, j] = 0;
                        }
                    }
                }
                return Z;
            }
            public Matrix Vid(Matrix X)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Z.elements[i, j] = X.elements[j, i];
                    }
                }
                return Z;
            }
            public Matrix DoubleVid(Matrix X)
            {
                Matrix Z = new Matrix(N);
                Z = Vid(X);
                Z = Zap(Z);
                return Z;
            }

            public Matrix Com(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix(N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Z.elements[i, j] = 0;
                        for (int k = 0; k < N; k++)
                        {
                            Z.elements[i, j] += X.elements[i, k] * Y.elements[k, j];
                        }
                        if (Z.elements[i, j] > 0)
                        {
                            Z.elements[i, j] = 1;
                        }
                    }
                }
                return Z;
            }

            public Matrix Zvuj(Matrix X, Matrix Y)
            {
                Matrix Z = new Matrix();
                int t = 0;
                for(int i=0;i<N;i++)
                {
                    for(int j=0;j<N;j++)
                    {
                        if ((i == Y.elements[0, 0] || i == Y.elements[0, 1]) && (j == Y.elements[0, 0] || j == Y.elements[0, 1]))
                        {
                            if (t < 2)
                                Z.elements[0, t] = X.elements[i, j];
                            else if (t >= 2)
                            {
                                Z.elements[1, t - 2] = X.elements[i, j];
                            }
                            t++;
                                
                        }
                    }
                }
                return Z;
            }

        }
        static void Main(string[] args)
        {
            Matrix R = new Matrix(5);
            R.InitR();
            R.Print();
            bool check = false;
            check = Ref(R);
            if(check)
                Console.WriteLine("R рефлексивне");
            else
                Console.WriteLine("R не рефлексивне");
            check = AnRef(R);
            if (check)
                Console.WriteLine("R антирефлексивне");
            else
                Console.WriteLine("R не антирефлексивне");
            check = Sym(R);
            if (check)
                Console.WriteLine("R симетричне");
            else
                Console.WriteLine("R не симетричне");
            check = ASym(R);
            if (check)
                Console.WriteLine("R асиметричне");
            else
                Console.WriteLine("R не асиметричне");
            check = AnSym(R);
            if (check)
                Console.WriteLine("R антисиметричне");
            else
                Console.WriteLine("R не антисиметричне");
            check = Tranz(R);
            if (check)
                Console.WriteLine("R транзитивне");
            else
                Console.WriteLine("R не транзитивне");
            check = NegTranz(R);
            if (check)
                Console.WriteLine("R негативно транзитивне");
            else
                Console.WriteLine("R не негативно транзитивне");
            check = ForceTranz(R);
            if (check)
                Console.WriteLine("R сильно транзитивне");
            else
                Console.WriteLine("R не сильно транзитивне");
            check = Zvyaz(R);
            if (check)
                Console.WriteLine("R зв'язне");
            else
                Console.WriteLine("R не зв'язне");
            
            Console.ReadKey();
        }

        public static bool Ref(Matrix X)
        {
            bool equal = true;
            while (equal)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i == j)
                        {
                            if (X.elements[i, j] == 1)
                                continue;
                            else
                                equal = false;
                        }
                    }
                }
                break;
            }
            return equal;
        }
        public static bool AnRef(Matrix X)
        {
            bool equal = true;
            while (equal)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i == j)
                        {
                            if (X.elements[i, j] == 0)
                                continue;
                            else
                                equal = false;
                        }
                    }
                }
                break;
            }
            return equal;
        }

        public static bool Sym(Matrix X)
        {
            bool equal = false;
            if (Vkl(X, X.Vid(X)))
                equal = true;
            return equal;
        }
        public static bool ASym(Matrix X)
        {
            bool equal = true;
            Matrix Y = X.Con(X, X.Vid(X));
            while (equal)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        
                            if (X.elements[i, j] == 0)
                                continue;
                            else
                                equal = false;
                        
                    }
                }
                break;
            }
            return equal;
        }
        public static bool AnSym(Matrix X)
        {
            bool equal = true;
            Matrix Y = X.Con(X, X.Vid(X));
            while (equal)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i != j)
                        {
                            if (X.elements[i, j] == 0)
                                continue;
                            else
                                equal = false;
                        }
                    }
                }
                break;
            }
            return equal;
        }
        public static bool Tranz(Matrix X)
        {
            bool equal = false;
            if (Vkl(X.Com(X, X), X))
                equal = true;
            return equal;
        }
        public static bool NegTranz(Matrix X)
        {
            bool equal = false;
            if (Tranz(X.Zap(X))) 
                equal = true;
            return equal;
        }
        public static bool ForceTranz(Matrix X)
        {
            bool equal = false;
            if (Tranz(X.Zap(X)) && Tranz(X)) 
                equal = true;
            return equal;
        }

        public static bool Zvyaz(Matrix X)
        {
            bool equal = false;
            if (Ref(X) && Sym(X) && Tranz(X))
                equal = true;
            return equal;
        }
        

        public static bool Equal(Matrix X, Matrix Y)
        {
            bool equal = true;
            while (equal)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {

                        if (X.elements[i, j] == Y.elements[i, j])
                            continue;
                        else
                            equal = false;

                    }
                }
            }
            return equal;
        }
        public static bool Vkl(Matrix X, Matrix Y)
        {
            bool vkl = true;
            while (vkl)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (X.elements[i, j] <= Y.elements[i, j])
                            continue;
                        else
                            vkl = false;
                    }
                }
            }
            return vkl;
        }
    }
}
