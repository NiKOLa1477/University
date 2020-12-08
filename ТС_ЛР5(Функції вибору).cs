using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lab5_olga
{
    class Program
    {
        public static int[,] R = { { 1, 1, 0, 0, 1, 0 }, { 1, 1, 0, 0, 1, 0 }, { 1, 0, 1, 1, 1, 1 }, { 0, 1, 1, 1, 0, 1 }, { 0, 0, 1, 0, 1, 1 }, { 0, 1, 0, 1, 0, 1 } };
        static void Main(string[] args)
        {
            var Rmat0 = new Matrix(R);
            Rmat0.Print();

            Console.WriteLine("Вiдношення строгої переваги");
            var Rmat = Difference(Rmat0, Rmat0.Invert());
            Rmat.Print();

            var q = selectionFunctionOne(Rmat);
            for (int j = 1; j <= q.Count; j++)
            {
                Console.WriteLine($"C(x{j})=x{q[j - 1]}");
            }

            selectionFunctionTwo(Rmat);
            selectionFunctionThree(Rmat);
            selectionFunctionFour(Rmat);
            selectionFunctionFive(Rmat);

            selectionFunctionSix(Rmat);
            Rmat.Print();

            Console.ReadLine();
        }

        public class Matrix
        {
            public int[,] mat { get; private set; }

            public Matrix(int[,] arr)
            {
                mat = arr;
            }

            public void Print()
            {
                for (int i = 0; i < mat.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < mat.Length / (mat.GetUpperBound(0) + 1); j++)
                    {
                        Console.Write(mat[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            }

            public Matrix Invert()
            {
                int[,] res = new int[mat.GetUpperBound(0) + 1, mat.Length / (mat.GetUpperBound(0) + 1)];

                for (int i = 0; i < mat.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < mat.Length / (mat.GetUpperBound(0) + 1); j++)
                    {
                        res[i, j] = mat[j, i];
                    }
                }

                return new Matrix(res);
            }
        }


        public static Matrix Difference(Matrix first, Matrix second)
        {
            var res = new Matrix(new int[first.mat.GetUpperBound(0) + 1, first.mat.Length / (first.mat.GetUpperBound(0) + 1)]);

            for (int i = 0; i < first.mat.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < first.mat.Length / (first.mat.GetUpperBound(0) + 1); j++)
                {
                    res.mat[i, j] = first.mat[i, j] - second.mat[i, j];
                    if (res.mat[i, j] < 0)
                    {
                        res.mat[i, j] = 0;
                    }
                }
            }

            return res;
        }

        public static Matrix Narowing(Matrix mat1, int first, int second)
        {
            Matrix res = new Matrix(new int[2, 2]);

            first = first - 1;
            second = second - 1;

            res.mat[0, 0] = mat1.mat[first, first];
            res.mat[0, 1] = mat1.mat[first, second];
            res.mat[1, 0] = mat1.mat[second, first];
            res.mat[1, 1] = mat1.mat[second, second];
            return res;
        }

        public static Matrix Narowing(Matrix mat1, int first, int second, int third)
        {
            Matrix res = new Matrix(new int[3, 3]);

            first = first - 1;
            second = second - 1;
            third = third - 1;

            res.mat[0, 0] = mat1.mat[first, first];
            res.mat[0, 1] = mat1.mat[first, second];
            res.mat[0, 2] = mat1.mat[first, third];
            res.mat[1, 0] = mat1.mat[second, first];
            res.mat[1, 1] = mat1.mat[second, second];
            res.mat[1, 2] = mat1.mat[second, third];
            res.mat[2, 0] = mat1.mat[third, first];
            res.mat[2, 1] = mat1.mat[third, second];
            res.mat[2, 2] = mat1.mat[third, third];
            return res;
        }

        public static Matrix Narowing(Matrix mat1, int first, int second, int third, int fourth)
        {
            Matrix res = new Matrix(new int[4, 4]);

            first = first - 1;
            second = second - 1;
            third = third - 1;
            fourth = fourth - 1;


            res.mat[0, 0] = mat1.mat[first, first];
            res.mat[0, 1] = mat1.mat[first, second];
            res.mat[0, 2] = mat1.mat[first, third];
            res.mat[0, 3] = mat1.mat[first, fourth];
            res.mat[1, 0] = mat1.mat[second, first];
            res.mat[1, 1] = mat1.mat[second, second];
            res.mat[1, 2] = mat1.mat[second, third];
            res.mat[1, 3] = mat1.mat[second, fourth];
            res.mat[2, 0] = mat1.mat[third, first];
            res.mat[2, 1] = mat1.mat[third, second];
            res.mat[2, 2] = mat1.mat[third, third];
            res.mat[2, 3] = mat1.mat[third, fourth];
            res.mat[3, 0] = mat1.mat[fourth, first];
            res.mat[3, 1] = mat1.mat[fourth, second];
            res.mat[3, 2] = mat1.mat[fourth, third];
            res.mat[3, 3] = mat1.mat[fourth, fourth];
            return res;
        }

        public static Matrix Narowing(Matrix mat1, int first, int second, int third, int fourth, int fifth)
        {
            Matrix res = new Matrix(new int[5, 5]);

            first = first - 1;
            second = second - 1;
            third = third - 1;
            fourth = fourth - 1;
            fifth = fifth - 1;

            res.mat[0, 0] = mat1.mat[first, first];
            res.mat[0, 1] = mat1.mat[first, second];
            res.mat[0, 2] = mat1.mat[first, third];
            res.mat[0, 3] = mat1.mat[first, fourth];
            res.mat[0, 4] = mat1.mat[first, fifth];
            res.mat[1, 0] = mat1.mat[second, first];
            res.mat[1, 1] = mat1.mat[second, second];
            res.mat[1, 2] = mat1.mat[second, third];
            res.mat[1, 3] = mat1.mat[second, fourth];
            res.mat[1, 4] = mat1.mat[second, fifth];
            res.mat[2, 0] = mat1.mat[third, first];
            res.mat[2, 1] = mat1.mat[third, second];
            res.mat[2, 2] = mat1.mat[third, third];
            res.mat[2, 3] = mat1.mat[third, fourth];
            res.mat[2, 4] = mat1.mat[third, fifth];
            res.mat[3, 0] = mat1.mat[fourth, first];
            res.mat[3, 1] = mat1.mat[fourth, second];
            res.mat[3, 2] = mat1.mat[fourth, third];
            res.mat[3, 3] = mat1.mat[fourth, fourth];
            res.mat[3, 4] = mat1.mat[fourth, fifth];
            res.mat[4, 0] = mat1.mat[fifth, first];
            res.mat[4, 1] = mat1.mat[fifth, second];
            res.mat[4, 2] = mat1.mat[fifth, third];
            res.mat[4, 3] = mat1.mat[fifth, fourth];
            res.mat[4, 4] = mat1.mat[fifth, fifth];

            return res;
        }

        public static List<int> findGreatest(Matrix mat)
        {
            List<int> res = new List<int>();

            for (int i = 0; i < mat.mat.GetUpperBound(0) + 1; i++)
            {
                int j2 = 0;
                for (int j = 0; j < mat.mat.Length / (mat.mat.GetUpperBound(0) + 1); j++)
                {
                    j2 += mat.mat[j, i];
                }

                if (j2 == 0)
                {
                    res.Add(i + 1);
                }
            }

            return res;
        }

        public static List<int> selectionFunctionOne(Matrix mat)
        {
            var res = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                res.Add(i + 1);
            }

            return res;
        }

        public static List<int[]> selectionFunctionTwo(Matrix mat)
        {
            var res = new List<int[]>();

            int temp = 2;

            for (int i = 1; i < 6; i++)
            {
                for (int j = temp; j <= 6; j++)
                {
                    var tmp = Narowing(mat, i, j);
                    tmp.Print();

                    foreach (var x in findGreatest(tmp))
                    {
                        if (x == 1)
                        {
                            Console.WriteLine($"C(x{i},x{j})=x{i}");
                        }

                        if (x == 2)
                        {
                            Console.WriteLine($"C(x{i},x{j})=x{j}");
                        }
                    }

                    Console.WriteLine();

                    if (j == 6)
                    {
                        temp++;
                    }
                }
            }

            return res;
        }

        public static List<int[]> selectionFunctionThree(Matrix mat)
        {
            var res = new List<int[]>();

            int temp0 = 1;

            int temp = 2;

            int temp2 = 3;

            for (int i = temp0; i < 6; i++)
            {
                for (int j = temp; j <= 6; j++)
                {
                    for (int k = temp2; k <= 6; k++)
                    {
                        var tmp = Narowing(mat, i, j, k);
                        tmp.Print();

                        foreach (var x in findGreatest(tmp))
                        {
                            if (x == 1)
                            {
                                Console.WriteLine($"C(x{i},x{j},x{k})=x{i}");
                            }

                            if (x == 2)
                            {
                                Console.WriteLine($"C(x{i},x{j},x{k})=x{j}");
                            }
                            if (x == 3)
                            {
                                Console.WriteLine($"C(x{i},x{j},x{k})=x{k}");
                            }
                            
                        }

                        Console.WriteLine();
                        if (k == 6)
                        {
                            temp2++;
                            temp0++;
                            temp++;
                        }
                    }
                    break;
                }
            }
            return res;
        }

        public static List<int[]> selectionFunctionFour(Matrix mat)
        {
            var res = new List<int[]>();

            var tmp = Narowing(mat, 1, 2, 3, 4);
            tmp.Print();
            int[] indexarr = { 1, 2, 3, 4 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x4)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 3, 5);
            tmp.Print();
            indexarr = new[] { 1, 2, 3, 5 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x5)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 3, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 3, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 4, 5);
            tmp.Print();
            indexarr = new[] { 1, 2, 4, 5 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x4,x5)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 4, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 4, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x4,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x2,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 3, 4, 5);
            tmp.Print();
            indexarr = new[] { 1, 3, 4, 5 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x3,x4,x5)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 3, 4, 6);
            tmp.Print();
            indexarr = new[] { 1, 3, 4, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x3,x4,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 3, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 3, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x3,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 4, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x1,x4,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 2, 3, 4, 5);
            tmp.Print();
            indexarr = new[] { 2, 3, 4, 5 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x2,x3,x4,x5)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 2, 3, 4, 6);
            tmp.Print();
            indexarr = new[] { 2, 3, 4, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x2,x3,x4,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 2, 3, 5, 6);
            tmp.Print();
            indexarr = new[] { 2, 3, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x2,x3,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 2, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 2, 4, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x2,x4,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 3, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 3, 4, 5, 6 };

            for (int i = 0; i < 4; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i])
                {
                    Console.WriteLine("C(x3,x4,x5,x6)=x" + indexarr[i]);
                }
            }
            return res;
        }

        public static List<int[]> selectionFunctionFive(Matrix mat)
        {
            var res = new List<int[]>();

            Console.WriteLine();
            var tmp = Narowing(mat, 1, 2, 3, 4, 5);
            int[] indexarr = { 1, 2, 3, 4, 5 };
            tmp.Print();
            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x4,x5)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 3, 4, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 3, 4, 6 };

            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x4,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 3, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 3, 5, 6 };

            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x1,x2,x3,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 2, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 2, 4, 5, 6 };

            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x1,x2,x4,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 1, 3, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 1, 3, 4, 5, 6 };

            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x1,x3,x4,x5,x6)=x" + indexarr[i]);
                }
            }

            Console.WriteLine();
            tmp = Narowing(mat, 2, 3, 4, 5, 6);
            tmp.Print();
            indexarr = new[] { 2, 3, 4, 5, 6 };

            for (int i = 0; i < 5; i++)
            {
                if (tmp.mat[0, i] == tmp.mat[1, i] && tmp.mat[1, i] == tmp.mat[2, i] &&
                    tmp.mat[2, i] == tmp.mat[3, i] && tmp.mat[3, i] == tmp.mat[4, i])
                {
                    Console.WriteLine("C(x2,x3,x4,x5,x6)=x" + indexarr[i]);
                }
            }
            return res;
        }

        public static List<int[]> selectionFunctionSix(Matrix mat)
        {
            var res = new List<int[]>();
            var x = findGreatest(mat);

            Console.WriteLine();            
            foreach (var o in x)
            {
                Console.WriteLine("C(x1,x2,x3,x4,x5,x6)=x" + o);
            }
            return res;
        }
    }
}
