
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MP_4
{
    class Program
    {
        const int N = 6;
        static int lenx=0, leny=0;
        static int[] C ;
        static Dart[] B;

        static Char[] z;
        static Char[] x = { 'T', 'B', 'H', 'D', 'S', 'A', 'V' }, y = { 'K', 'I', 'B', 'Y', 'S', 'V' };

        static void Main(string[] args)
        {

            Len();

            LevDinam();
            string first = "Вол";
            string second = "Колун";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Первая строка S1(300): " + RandomString(300));
            Console.WriteLine("Вторая строка S2(250): " + RandomString(250));

            sw.Stop();
            Console.WriteLine($"Затраченное время: " + sw.Elapsed);


            //Console.WriteLine("Дистанция Левенштейна рекурсией: " + LevensteinRecursion("АБВГДЕЁЖЗИЙКЛМН", "абвгдеёжзийклмн"));

            Console.WriteLine($"Затраченное время: " + sw.Elapsed);
            sw.Reset();
            sw.Start();

            Console.WriteLine("Дистанция Левенштейна динамически: " + LevensteinDynamic("АБВГДЕЁЖЗИЙКЛ", "абвгдеёжзийкл"));

            sw.Stop();
            Console.WriteLine($"Затраченное время: " + sw.Elapsed);
            sw.Reset();
            sw.Start();

            Console.WriteLine("(Рекурсия) Дистанция Левенштейна для слов " + first + " и " + second + " : " + LevensteinRecursion(first, second));

            sw.Stop();
            Console.WriteLine($"Затраченное время: " + sw.Elapsed);
            sw.Reset();
            sw.Start();
            Console.WriteLine("(Динамика) Дистанция Левенштейна для слов " + first + " и " + second + " : " + LevensteinDynamic(first, second));

            sw.Stop();
            Console.WriteLine($"Затраченное время: " + sw.Elapsed);
            Console.ReadLine();
           // MatrixRecursion();
            //MatrixDynamic();
            //Console.ReadLine();

        }
        public static string RandomString(int n)
        {
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPWRSTUVWXYZabcdefghijklmnopwrstuvwxyz";
            string stroka = "";
            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    stroka = stroka.Insert(stroka.Length, alphabet[random.Next(0, alphabet.Length)].ToString());
                }
            }
            return stroka;
        }

        public static int LevensteinRecursion(string first, string second)
        {
            if (first == second)
            {
                return 0;
            }
            if (first == "")
            {
                return second.Length;
            }
            if (second == "")
            {
                return first.Length;
            }
            else
            {
                int firstLenght = first.Length, secondLenght = second.Length;
                int[] result = new int[3];
                
                result[0] = LevensteinRecursion(first.Substring(0, firstLenght - 1), second) + 1;
                result[1] = LevensteinRecursion(first, second.Substring(0, secondLenght - 1)) + 1;
                result[2] = LevensteinRecursion(first.Substring(0, firstLenght - 1), second.Substring(0, secondLenght - 1))
                    + ((first[firstLenght - 1] == second[secondLenght - 1]) ? 0 : 1);

                return result.Min();
            }
        }

        public static int LevensteinDynamic(string first, string second)
        {
            int firstLenght = first.Length, secondLenght = second.Length;
            int[,] result = new int[(firstLenght + 1), (secondLenght + 1)];

            for (int i = 0; i <= firstLenght; i++)
            {
                result[i, 0] = i;
            }
            for (int j = 0; j <= secondLenght; j++)
            {
                result[0, j] = j;
            }
            for (int i = 1; i <= firstLenght; i++)
            {
                for (int j = 1; j <= secondLenght; j++)
                {
                    result[i, j] = GetMin(result[i - 1, j] + 1, result[i, j - 1] + 1,
                                   result[i - 1, j - 1] + (first[i - 1] == second[j - 1] ? 0 : 1));
                }
            }
            return result[firstLenght, secondLenght];
        }

        private static int GetMin(int xs, int ys, int zs)
        {
            return
                (xs < ys && xs < zs) ? xs :
                (ys < xs && ys < zs) ? ys : zs;
        }

        public static void MatrixRecursion()
        {
            int[] Mc = new int[N + 1] { 9, 12, 20, 23, 30, 40, 51 };
            int[,] Ms = new int[N, N];
            int result = 0;

            result = MatrixRecursionRecursion(1, N, N, Mc, Ms);
            Console.WriteLine("(Рекурсия) Задача о расстановке скобок при перемножении матриц\nРазмерности матриц: ");
            for (int i = 1; i <= N; i++)
            {
                Console.Write("(" + Mc[i - 1] + ", " + Mc[i] + ") ");
            }
            Console.WriteLine("\nМинимальное количество операций умножения: " + result);
            Console.WriteLine("Матрица S: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Ms[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int MatrixRecursionRecursion(int i, int j, int n, int[] c, int[,] s)
        {
            int result = Int32.MaxValue, tempResult = Int32.MaxValue;
            if (i < j)
            {
                for (int k = i; k < j; k++)
                {
                    tempResult = MatrixRecursionRecursion(i, k, n, c, s)
                        + MatrixRecursionRecursion(k + 1, j, n, c, s)
                        + c[i - 1] * c[k] * c[j];
                    if (tempResult < result)
                    {
                        result = tempResult;
                        s[i- 1, j - 1] = k;
                    }
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static void MatrixDynamic()
        {
            int[] Mc = new int[N + 1] { 9, 12, 20, 23, 30, 40, 51 };
            int[,] Ms = new int[N, N];
            int result = 0;
            result = MatrixDynamicCicle(N, Mc, Ms);
            Console.WriteLine("(Динамика) Задача о расстановке скобок при перемножении матриц\nРазмерности матриц: ");
            for (int i = 1; i <= N; i++)
            {
                Console.Write("(" + Mc[i - 1] + ", " + Mc[i] + ") ");
            }
            Console.WriteLine("\nМинимальное количество операций умножения: " + result);
            Console.WriteLine("Матрица S: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Ms[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int MatrixDynamicCicle(int n, int[] c, int[,] s)
        {
            int[,] M = new int[n, n];
            int j = 0, q = 0;
            for (int i = 1; i <= n; i++)
            {
                s[i - 1, i - 1] = 0;
            }
            for (int l = 2; l <= n; l++)
            {
                for (int i = 1; i <= n - l + 1; i++)
                {
                    j = i + l - 1;
                    M[i - 1, j - 1] = Int32.MaxValue;
                    for (int k = i; k <= j - 1; k++)
                    {
                        q = M[i - 1, k - 1] + M[k, j - 1] + c[i - 1] * c[k] * c[j];
                        if (q < M[i - 1, j - 1])
                        {
                            M[i - 1, j - 1] = q;
                            s[i - 1, j - 1] = k;
                        }
                    }
                }
            }
            return M[0, n - 1];
        }

        public static void Len()//рекурсивное вычисление длины наибольшей общей подпоследовательности
        {
            Char[] X = { 'T', 'B', 'H', 'D', 'S', 'A', 'V' }, Y = { 'K', 'I', 'B', 'Y', 'S', 'V' };
            Console.WriteLine("-- вычисление длины LCS для X и Y(рекурсия)");
            Console.Write("Последовательность X: ");
            foreach(char item in X)
                Console.Write(item + " ");
            Console.Write("Последовательность Y: ");
            foreach (char item in Y)
                Console.Write(item + " ");
            int s = lcs(
                        X.Length - 1,  // длина   последовательности  X   
                        X,       // последовательность X
                        Y.Length - 1,  // длина   последовательности  Y
                        Y       // последовательность Y
                       );
            Console.WriteLine();
            Console.WriteLine("-- длина LCS: " + s);
        }

        public static int lcs(int lensx, char[] x, int lensy, char[] y)      
        { 
            int rc = 0;  
            if (lensx > 0 && lensy > 0)
            {
                if (x[lensx - 1] == y[lensy - 1]) rc = 1 + lcs(lensx-1, x, lensy-1, y);    
                else rc = Math.Max(lcs(lensx, x, lensy-1, y), lcs(lensx-1, x, lensy, y)); 
            }
            return rc;
        }

        //Динамическое вычисление длины наибольшей общей подпоследовательности
        public static void LevDinam()
        {
            int l = Lcsd(x, y, z);
            Console.WriteLine("-- вычисление длины LCS для X и Y(динамически)");
            Console.WriteLine("-- Последрвательность LCS: ");
            foreach (char item in x)
                Console.Write(item + " ");
            Console.WriteLine("-- Последовательность Y: ");
            foreach (char item in y)
                Console.Write(item + " ");
            Console.WriteLine("-- длина LCS: " + l);
        }

        public enum Dart { TOP, LEFT, LEFTTOP };



        public static int Lcsd(char[] x, char[] y, char[] z)
        {
            int lenx = x.Length, leny = y.Length;
            z = new char[lenx*leny];
            int[] C = new int[(lenx + 1) * (leny + 1)];
            Dart[] B = new Dart[(lenx + 1) * (leny + 1)];
            for (int cs = 0; cs < C.Length; cs++)
            C[cs] = 0;
            for (int i = 1; i <= lenx; i++)
                for (int j = 1; j <= leny; j++)
                    if (x[(i)-1] == y[(j) - 1])
                    {
                        C[(i) * (leny + 1) + (j)] = C[(i-1) * (leny + 1) + (j-1)] + 1;
                        B[(i) * (leny + 1) + (j)] = Dart.LEFTTOP;
                    }
                    else if (C[(i-1) * (leny + 1) + (j)] >= C[(i) * (leny + 1) + (j-1)])
                    {
                        C[(i) * (leny + 1) + (j)] = C[(i-1) * (leny + 1) + (j)];
                        B[(i) * (leny + 1) + (j)] = Dart.TOP;
                    }
                    else
                    {
                        C[(i) * (leny + 1) + (j)] = C[(i) * (leny + 1) + (j-1)];
                        B[(i) * (leny + 1) + (j)] = Dart.LEFT;
                    }
            getLCScontent(lenx, leny, x, B, C[(lenx) * (leny + 1) + (leny)], lenx, leny, z);
            return C[(lenx) * (leny + 1) + (leny)];
        }

        public static void getLCScontent(int lenx, int leny, char[] x, Dart[] B, int n, int i, int j, char[] z)
        {
            if ((i > 0 && j > 0 && n > 0))
            {
                if (B[(i) * (leny + 1) + (j)] == Dart.LEFTTOP)
                {
                    getLCScontent(lenx, leny, x, B, n - 1, i - 1, j - 1, z);
                    z[(n) - 1] = x[(i) - 1];
                    z[n] = '0';
                }
                else if (B[(i) * (leny + 1) + (j)] == Dart.TOP)
                    getLCScontent(lenx, leny, x, B, n, i - 1, j, z);
                else getLCScontent(lenx, leny, x, B, n, i, j - 1, z);
            }
        }

    }
}
