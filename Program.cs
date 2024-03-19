using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
            int[] mValues = { 2, 4, 6, 8, 10 }; 
            int[] nValues = { 2, 4, 6, 8, 10 }; 

            foreach (int m in mValues)
            {
                foreach (int n in nValues)
                {
                    Console.WriteLine($"Проводимо експеримент для m={m}, l={n}:");
                    Console.WriteLine("----------------------------------------");

                    double[,] A = MatrixOperations.CreateMaxtrixA(m, n);
                    double[] B = MatrixOperations.CreateVectorB(n);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    double [] C = MatrixOperations.MultiplyMatrix(A, B);
                    stopwatch.Stop();

                    Console.WriteLine($"Час виконання: {stopwatch.Elapsed.TotalMilliseconds} мілісекунд(и)\n");

                    Console.WriteLine("Матриця A:");
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            Console.Write(A[i, j].ToString("F3") + "\t");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nВектор B:");
                    for (int i = 0; i < B.GetLength(0); i++)
                    {
                        Console.Write(B[i].ToString("F3") + "\t");
                    }

                    Console.WriteLine("\nВектор C:");
                    for (int i = 0; i < C.GetLength(0); i++)
                    {
                        Console.Write(C[i].ToString("F3") + "\t");
                    }

                    Console.WriteLine("\n\n");
                }
            }

        }
    }
}
