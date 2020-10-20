using System;

namespace ST_LW3
{
    class Program
    {
        public static int N = 6;

        public class Matrix
        {
            public int[,] elements;
            public bool[] row;

            public Matrix()
            {
                elements = new int[2, 2];
            }
            public Matrix(int n)
            {
                elements = new int[n, n];
                row = new bool[n];
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
                elements[0, 4] = 1;
                elements[1, 0] = 1;
                elements[1, 1] = 1;
                elements[1, 4] = 1;
                elements[2, 0] = 1;
                elements[2, 2] = 1;
                elements[2, 3] = 1;
                elements[2, 4] = 1;
                elements[2, 5] = 1;
                elements[3, 1] = 1;
                elements[3, 2] = 1;
                elements[3, 3] = 1;
                elements[3, 5] = 1;
                elements[4, 2] = 1;
                elements[4, 4] = 1;
                elements[4, 5] = 1;
                elements[5, 1] = 1;
                elements[5, 3] = 1;
                elements[5, 5] = 1;

            }
            public void InitOmega()
            {
                for (int i = 0; i < N; i++) 
                {
                    for (int j = 0; j < N; j++) 
                    {
                        elements[i, j] = 1;
                    }
                }
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

            public bool Ch(int n, Choice C)
            {
                bool check = false;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (elements[n, i] == 1 && i == C.Body[j])
                        {
                            check = true;
                            break;
                        }
                    }
                }
                return check;
            }          
        }

        public class Choice
        {
            public bool[] El;
            public int[] Body;

            public Choice()
            {
                El = new bool[N];
                Body = new int[N];
            }
            public Choice(int a, int b, int c, int d, int e, int f)
            {
                El = new bool[N];
                Body = new int[N];
                Body[0] = a-1;
                Body[1] = b-1;
                Body[2] = c-1;
                Body[3] = d-1;
                Body[4] = e-1;
                Body[5] = f-1;
            }

            public void ElCheck(Matrix X)
            {
                bool zero = false;
                for(int i=0;i<N;i++)
                {
                    if(Body[i]>=0)
                    {
                        El[i] = X.Ch(Body[i], this);                        
                    }
                }                
            }
            public void Print()
            {
                bool zero = true; ;
                for (int i = 0; i < N; i++)
                {
                    if (El[i])
                    {
                        Console.Write($"x{i + 1} ");
                        zero = false;
                    }
                }
                if(zero)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if(Body[i]>=0)
                            Console.Write($"x{i + 1} ");                            
                    }
                }
                Console.WriteLine(")");
            }
        }
        static void Main(string[] args)
        {
            Matrix R = new Matrix(6);
            R.InitR();
            Console.WriteLine("Вiдношення R");
            R.Print();
            Console.WriteLine();
            Console.WriteLine("Вiдношення строгої переваги");
            Matrix T = R.Riz(R, R.Vid(R));
            T.Print();
            Console.WriteLine();
            ChFunc(T, 1, 2, 3, 4, 5, 6);
            Console.WriteLine();
            ChFunc(T, 1, 2, 3, 4, 5, 0);
            ChFunc(T, 1, 2, 3, 4, 0, 6);
            ChFunc(T, 1, 2, 3, 0, 5, 6);
            ChFunc(T, 1, 2, 0, 4, 5, 6);
            ChFunc(T, 1, 0, 3, 4, 5, 6);
            ChFunc(T, 0, 2, 3, 4, 5, 6);
            Console.WriteLine();
            ChFunc(T, 1, 2, 3, 4, 0, 0);
            ChFunc(T, 1, 2, 3, 0, 5, 0);
            ChFunc(T, 1, 2, 0, 4, 5, 0);
            ChFunc(T, 1, 0, 3, 4, 5, 0);
            ChFunc(T, 0, 2, 3, 4, 5, 0);
            ChFunc(T, 1, 2, 3, 4, 0, 0);
            ChFunc(T, 1, 2, 3, 0, 0, 6);
            ChFunc(T, 1, 2, 0, 4, 0, 6);
            ChFunc(T, 1, 0, 3, 4, 0, 6);
            ChFunc(T, 0, 2, 3, 4, 0, 6);
            ChFunc(T, 1, 2, 3, 0, 5, 0);
            ChFunc(T, 1, 2, 3, 0, 0, 6);
            ChFunc(T, 1, 2, 0, 0, 5, 6);
            ChFunc(T, 1, 0, 3, 0, 5, 6);
            ChFunc(T, 0, 2, 3, 0, 5, 6);            
            Console.WriteLine();
            ChFunc(T, 1, 2, 3, 0, 0, 0);
            ChFunc(T, 1, 2, 0, 4, 0, 0);
            ChFunc(T, 1, 2, 0, 0, 5, 0);
            ChFunc(T, 1, 2, 0, 0, 0, 6);
            ChFunc(T, 1, 0, 3, 4, 0, 0);
            ChFunc(T, 1, 0, 3, 0, 5, 0);
            ChFunc(T, 1, 0, 3, 0, 0, 6);
            ChFunc(T, 1, 0, 0, 4, 5, 0);
            ChFunc(T, 1, 0, 0, 4, 0, 6);
            ChFunc(T, 1, 0, 0, 0, 5, 6);
            ChFunc(T, 0, 2, 3, 4, 0, 0);
            ChFunc(T, 0, 2, 3, 0, 5, 0);
            ChFunc(T, 0, 2, 3, 0, 0, 6);
            ChFunc(T, 0, 2, 0, 4, 5, 0);
            ChFunc(T, 0, 2, 0, 4, 0, 6);
            ChFunc(T, 0, 2, 0, 0, 5, 6);
            ChFunc(T, 0, 0, 3, 4, 5, 0);
            ChFunc(T, 0, 0, 3, 4, 0, 6);
            ChFunc(T, 0, 0, 3, 0, 5, 6);
            ChFunc(T, 0, 0, 0, 4, 5, 6);
            Console.WriteLine();
            ChFunc(T, 1, 2, 0, 0, 0, 0);
            ChFunc(T, 1, 0, 3, 0, 0, 0);
            ChFunc(T, 1, 0, 0, 4, 0, 0);
            ChFunc(T, 1, 0, 0, 0, 5, 0);
            ChFunc(T, 1, 0, 0, 0, 0, 6);
            ChFunc(T, 0, 2, 3, 0, 0, 0);
            ChFunc(T, 0, 2, 0, 4, 0, 0);
            ChFunc(T, 0, 2, 0, 0, 5, 0);
            ChFunc(T, 0, 2, 0, 0, 0, 6);
            ChFunc(T, 0, 0, 3, 4, 0, 0);
            ChFunc(T, 0, 0, 3, 0, 5, 0);
            ChFunc(T, 0, 0, 3, 0, 0, 6);
            ChFunc(T, 0, 0, 0, 4, 5, 0);
            ChFunc(T, 0, 0, 0, 4, 0, 6);
            ChFunc(T, 0, 0, 0, 0, 5, 6);
            Console.WriteLine();
            ChFunc(T, 1, 0, 0, 0, 0, 0);
            ChFunc(T, 0, 2, 0, 0, 0, 0);
            ChFunc(T, 0, 0, 3, 0, 0, 0);
            ChFunc(T, 0, 0, 0, 4, 0, 0);
            ChFunc(T, 0, 0, 0, 0, 5, 0);
            ChFunc(T, 0, 0, 0, 0, 0, 6);
            Console.WriteLine();
            Matrix X = new Matrix(6);
            X = BuildChMatrix(T);
            X = X.Zap(X);
            Console.WriteLine("Побудоване за функцiями переваги вiдношення");
            X.Print();
            
            
            Console.ReadKey();
        }

        public static Matrix ChMatrix(Matrix Z, Matrix X, int a, int b, int c, int d, int e, int f)
        {
            Choice C = new Choice(a, b, c, d, e, f);
            C.ElCheck(Z);
            Matrix Y = new Matrix(6);
            int[] k = new int[6];
            for(int i=0;i<N;i++)
            {
                if(C.Body[i]>=0)
                {
                    if(!C.El[i])
                    {
                        for(int j=0;j<N;j++)
                        {
                            Y.elements[i, j] = 1;
                        }
                        k[i] = 1;
                    }
                }
            }
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if ((j == a - 1 || j == b - 1 || j == c - 1 || j == d - 1 || j == e - 1 || j == f - 1) && (i == a-1 || i == b-1 || i == c-1 || i == d-1 || i == e-1 || i == f-1 ) && !X.row[i])
                        X.elements[i, j] = Y.elements[i, j];
                }
            }
            for (int i = 0; i<N;i++)
            {
                if (k[i] > 0)
                    X.row[i] = true;
            }
            return X;
        }
        public static Matrix BuildChMatrix(Matrix X)
        {
            Matrix T = new Matrix(6);
            T = ChMatrix(X, T, 1, 2, 3, 4, 5, 6);

            int[] S = new int[6];
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    S[i] += X.elements[i, j];
                }
            }
            int max = S[0];
            for (int i = 1; i<N;i++)
            {
                if (S[i] > max)
                    max = S[i];
            }
            int k = N - max;
            if(k<6)
            {
                T = ChMatrix(X, T, 1, 2, 3, 4, 5, 0);
                T = ChMatrix(X, T, 1, 2, 3, 4, 0, 6);
                T = ChMatrix(X, T, 1, 2, 3, 0, 5, 6);
                T = ChMatrix(X, T, 1, 2, 0, 4, 5, 6);
                T = ChMatrix(X, T, 1, 0, 3, 4, 5, 6);
                T = ChMatrix(X, T, 0, 2, 3, 4, 5, 6);
            }
            if(k<5)
            {
                T = ChMatrix(X, T, 1, 2, 3, 4, 0, 0);
                T = ChMatrix(X, T, 1, 2, 3, 0, 5, 0);
                T = ChMatrix(X, T, 1, 2, 0, 4, 5, 0);
                T = ChMatrix(X, T, 1, 0, 3, 4, 5, 0);
                T = ChMatrix(X, T, 0, 2, 3, 4, 5, 0);
                T = ChMatrix(X, T, 1, 2, 3, 4, 0, 0);
                T = ChMatrix(X, T, 1, 2, 3, 0, 0, 6);
                T = ChMatrix(X, T, 1, 2, 0, 4, 0, 6);
                T = ChMatrix(X, T, 1, 0, 3, 4, 0, 6);
                T = ChMatrix(X, T, 0, 2, 3, 4, 0, 6);
                T = ChMatrix(X, T, 1, 2, 3, 0, 5, 0);
                T = ChMatrix(X, T, 1, 2, 3, 0, 0, 6);
                T = ChMatrix(X, T, 1, 2, 0, 0, 5, 6);
                T = ChMatrix(X, T, 1, 0, 3, 0, 5, 6);
                T = ChMatrix(X, T, 0, 2, 3, 0, 5, 6);
            }
            if(k<4)
            {
                T = ChMatrix(X, T, 1, 2, 3, 0, 0, 0);
                T = ChMatrix(X, T, 1, 2, 0, 4, 0, 0);
                T = ChMatrix(X, T, 1, 2, 0, 0, 5, 0);
                T = ChMatrix(X, T, 1, 2, 0, 0, 0, 6);
                T = ChMatrix(X, T, 1, 0, 3, 4, 0, 0);
                T = ChMatrix(X, T, 1, 0, 3, 0, 5, 0);
                T = ChMatrix(X, T, 1, 0, 3, 0, 0, 6);
                T = ChMatrix(X, T, 1, 0, 0, 4, 5, 0);
                T = ChMatrix(X, T, 1, 0, 0, 4, 0, 6);
                T = ChMatrix(X, T, 1, 0, 0, 0, 5, 6);
                T = ChMatrix(X, T, 0, 2, 3, 4, 0, 0);
                T = ChMatrix(X, T, 0, 2, 3, 0, 5, 0);
                T = ChMatrix(X, T, 0, 2, 3, 0, 0, 6);
                T = ChMatrix(X, T, 0, 2, 0, 4, 5, 0);
                T = ChMatrix(X, T, 0, 2, 0, 4, 0, 6);
                T = ChMatrix(X, T, 0, 2, 0, 0, 5, 6);
                T = ChMatrix(X, T, 0, 0, 3, 4, 5, 0);
                T = ChMatrix(X, T, 0, 0, 3, 4, 0, 6);
                T = ChMatrix(X, T, 0, 0, 3, 0, 5, 6);
                T = ChMatrix(X, T, 0, 0, 0, 4, 5, 6);
            }
            if(k<3)
            {
                T = ChMatrix(X, T, 1, 2, 0, 0, 0, 0);
                T = ChMatrix(X, T, 1, 0, 3, 0, 0, 0);
                T = ChMatrix(X, T, 1, 0, 0, 4, 0, 0);
                T = ChMatrix(X, T, 1, 0, 0, 0, 5, 0);
                T = ChMatrix(X, T, 1, 0, 0, 0, 0, 6);
                T = ChMatrix(X, T, 0, 2, 3, 0, 0, 0);
                T = ChMatrix(X, T, 0, 2, 0, 4, 0, 0);
                T = ChMatrix(X, T, 0, 2, 0, 0, 5, 0);
                T = ChMatrix(X, T, 0, 2, 0, 0, 0, 6);
                T = ChMatrix(X, T, 0, 0, 3, 4, 0, 0);
                T = ChMatrix(X, T, 0, 0, 3, 0, 5, 0);
                T = ChMatrix(X, T, 0, 0, 3, 0, 0, 6);
                T = ChMatrix(X, T, 0, 0, 0, 4, 5, 0);
                T = ChMatrix(X, T, 0, 0, 0, 4, 0, 6);
                T = ChMatrix(X, T, 0, 0, 0, 0, 5, 6);
            }
            if(k<2)
            {
                T = ChMatrix(X, T, 1, 0, 0, 0, 0, 0);
                T = ChMatrix(X, T, 0, 2, 0, 0, 0, 0);
                T = ChMatrix(X, T, 0, 0, 3, 0, 0, 0);
                T = ChMatrix(X, T, 0, 0, 0, 4, 0, 0);
                T = ChMatrix(X, T, 0, 0, 0, 0, 5, 0);
                T = ChMatrix(X, T, 0, 0, 0, 0, 0, 6);
            }
            return T;
        }

        public static void ChFunc(Matrix X, int a, int b, int c, int d, int e, int f)
        {
            Choice C = new Choice(a, b, c, d, e, f);
            C.ElCheck(X);
            Console.Write($"C(");
            for(int i=0;i<N;i++)
            {
                if(C.Body[i]>=0)
                {
                    Console.Write($"{C.Body[i] + 1} ");
                }
            }
            Console.Write(") = (");
            C.Print();
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
