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
            Matrix R1 = new Matrix(5);
            Matrix R2 = new Matrix(5);
            R1.InitR1();
            R2.InitR2();
            Console.WriteLine("R1");
            R1.Print();
            Console.WriteLine("R2");
            R2.Print();
            Matrix R = new Matrix(5);
            R = R.Con(R1, R2);
            Console.WriteLine("Перетин");
            R.Print();
            R = R.Dis(R1, R2);
            Console.WriteLine("Об'єднання");
            R.Print();
            R = R.Riz(R1, R2);
            Console.WriteLine("Рiзниця");
            R.Print();
            R = R.SymRiz(R1, R2);
            Console.WriteLine("Симетрична рiзниця");
            R.Print();
            R = R.Zap(R1);
            Console.WriteLine("Доповнення R1");
            R.Print();
            R = R.Zap(R2);
            Console.WriteLine("Доповнення R2");
            R.Print();
            R = R.Vid(R1);
            Console.WriteLine("Обернене вiдношення R1");
            R.Print();
            R = R.Vid(R2);
            Console.WriteLine("Обернене вiдношення R2");
            R.Print();
            R = R.DoubleVid(R1);
            Console.WriteLine("Двоїсте вiдношення R1");
            R.Print();
            R = R.DoubleVid(R2);
            Console.WriteLine("Двоїсте вiдношення R2");
            R.Print();
            R = R.Com(R1, R2);
            Console.WriteLine("Композицiя");
            R.Print();
            Matrix Q = new Matrix(1, 5);
            Matrix Z = new Matrix();
            Z = Z.Zvuj(R1, Q);
            Console.WriteLine("Звуження R1 на Q");
            Z.Print(2);
            Z = Z.Zvuj(R2, Q);
            Console.WriteLine("Звуження R2 на Q");
            Z.Print(2);
            bool check = Equal(R1, R2);
            if(check)
                Console.WriteLine("Матрицi R1 та R2 рiвнi");
            else
                Console.WriteLine("Матрицi R1 та R2 не рiвнi");
            check = Vkl(R1, R2);
            if (check)
                Console.WriteLine("Матриця R1 вкладається в R2");
            else
                Console.WriteLine("Матриця R1 не вкладається в R2");
            check = Vkl(R2, R1);
            if (check)
                Console.WriteLine("Матриця R2 вкладається в R1");
            else
                Console.WriteLine("Матриця R2 не вкладається в R1");
            Console.ReadKey();
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
