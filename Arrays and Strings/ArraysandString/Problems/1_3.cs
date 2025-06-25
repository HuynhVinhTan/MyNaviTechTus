using System;

namespace Problems
{
    public class B1_3
    {
        // Thay thế dấu cách bằng %20 trong chuỗi, chỉ xét đến độ dài thực
        public static string URLify(string str, int trueLength)
        {
            char[] arr = str.ToCharArray();
            int spaceCount = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (arr[i] == ' ') spaceCount++;
            }
            int newLength = trueLength + spaceCount * 2;
            char[] result = new char[newLength];
            int j = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (arr[i] == ' ')
                {
                    result[j++] = '%';
                    result[j++] = '2';
                    result[j++] = '0';
                }
                else
                {
                    result[j++] = arr[i];
                }
            }
            return new string(result);
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi: ");
            string input = Console.ReadLine();
            Console.Write("Nhập độ dài thực của chuỗi: ");
            int trueLength = int.Parse(Console.ReadLine());
            string output = URLify(input, trueLength);
            Console.WriteLine($"Kết quả: {output}");
        }
    }
}