using System;
using System.Collections.Generic;

namespace Problems
{
    public class B1_8
    {
        // Đặt dòng và cột về 0 nếu có phần tử bằng 0
        public static void ZeroMatrix(int[,] matrix, int m, int n)
        {
            HashSet<int> zeroRows = new HashSet<int>();
            HashSet<int> zeroCols = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroRows.Add(i);
                        zeroCols.Add(j);
                    }
                }
            }
            foreach (int row in zeroRows)
            {
                for (int j = 0; j < n; j++)
                    matrix[row, j] = 0;
            }
            foreach (int col in zeroCols)
            {
                for (int i = 0; i < m; i++)
                    matrix[i, col] = 0;
            }
        }

        public static void PrintMatrix(int[,] matrix, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Run()
        {
            Console.Write("Nhập số dòng M: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Nhập số cột N: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n];
            Console.WriteLine($"Nhập ma trận {m}x{n} (mỗi dòng {n} số, cách nhau bởi dấu cách):");
            for (int i = 0; i < m; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
            ZeroMatrix(matrix, m, n);
            Console.WriteLine("Ma trận sau khi xử lý:");
            PrintMatrix(matrix, m, n);
        }
    }
}