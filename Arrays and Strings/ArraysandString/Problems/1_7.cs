using System;

namespace Problems
{
    public class B1_7
    {
        // Xoay ma trận NxN 90 độ tại chỗ
        public static void RotateMatrix(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first, i];
                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];
                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];
                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];
                    // top -> right
                    matrix[i, last] = top;
                }
            }
        }

        public static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
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
            Console.Write("Nhập kích thước ma trận N: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Console.WriteLine($"Nhập ma trận {n}x{n} (mỗi dòng {n} số, cách nhau bởi dấu cách):");
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
            RotateMatrix(matrix, n);
            Console.WriteLine("Ma trận sau khi xoay 90 độ:");
            PrintMatrix(matrix, n);
        }
    }
}