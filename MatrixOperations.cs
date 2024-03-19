using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    internal class MatrixOperations
    {
        static double FunctionA(int i, int j)
        {
            return Math.Pow(Math.Tan(Math.Pow(j + 1, 3)), 2) / (i - i + 3) - Math.Pow(i, 2);
        }
        static double FunctionB(int j)
        {
            return Math.Pow(Math.Sin(Math.Pow(6 + j, 0.3)), 2) / (Math.Pow(j, 2) - 3);
        }
        public  static double [, ] CreateMaxtrixA(int n, int m)
        {
            double [,] matrixA = new double[n,m]; 
            for(int i = 0; i <n;i++)
            {
                for(int j = 0; j< m; j++)
                {
                    matrixA[i, j] = FunctionA(i, j);
                }
            }
            return matrixA;
        }
        public static double[] CreateVectorB(int n)
        {
            double[] vectorB = new double[n];
            for(int j = 0; j <n; j++)
            {
                vectorB[j] = FunctionB(j);
            }
            return vectorB;
        }
        public static double[] MultiplyMatrix(double[,] matrixA, double[] vectorB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            if (cols != vectorB.Length)
                throw new InvalidOperationException("Кількість стовпців у матриці повинна дорівнювати кількості елементів у векторі.");

            double[] result = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    result[i] += matrixA[i, j] * vectorB[j];
            }

            return result;
        }
    }
}
