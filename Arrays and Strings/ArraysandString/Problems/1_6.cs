using System;
using System.Text;

namespace Problems
{
    public class B1_6
    {
        // Nén chuỗi theo số lần lặp ký tự
        public static string CompressString(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(str[i - 1]);
                    sb.Append(count);
                    count = 1;
                }
            }
            sb.Append(str[str.Length - 1]);
            sb.Append(count);
            string compressed = sb.ToString();
            return compressed.Length < str.Length ? compressed : str;
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi: ");
            string input = Console.ReadLine();
            string output = CompressString(input);
            Console.WriteLine($"Kết quả: {output}");
        }
    }
}