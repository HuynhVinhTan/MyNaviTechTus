using System;

namespace Problems
{
    public class B1_5
    {
        // Kiểm tra hai chuỗi có cách nhau tối đa một phép chỉnh sửa
        public static bool OneEditAway(string first, string second)
        {
            int len1 = first.Length;
            int len2 = second.Length;
            if (Math.Abs(len1 - len2) > 1) return false;

            string s1 = len1 < len2 ? first : second;
            string s2 = len1 < len2 ? second : first;
            int i = 0, j = 0;
            bool foundDifference = false;
            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (s1.Length == s2.Length) i++; // thay thế
                }
                else
                {
                    i++;
                }
                j++;
            }
            return true;
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi thứ nhất: ");
            string s1 = Console.ReadLine();
            Console.Write("Nhập chuỗi thứ hai: ");
            string s2 = Console.ReadLine();
            bool result = OneEditAway(s1, s2);
            Console.WriteLine($"Kết quả: {result}");
        }
    }
}