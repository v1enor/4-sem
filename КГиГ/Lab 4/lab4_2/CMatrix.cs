using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_2
{
    public class CMatrix
    {
        public float[,] arr;
        int x = 0;
        int y = 0;

        public CMatrix(int x, int y)
        {
            arr = new float[x, y];
            this.x = x;
            this.y = y;
        }       
      
        public static float[,] Multiplication(float[,] a, float[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            float[,] r = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

       
    }
}
