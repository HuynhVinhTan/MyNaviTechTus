using System;

namespace Problems
{
    public class B1_9
    {
        // Kiểm tra s2 có phải là xoay vòng của s1 không
        public static bool IsRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length || s1.Length == 0) return false;
            string s1s1 = s1 + s1;
            return s1s1.Contains(s2);
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi thứ nhất: ");
            string s1 = Console.ReadLine();
            Console.Write("Nhập chuỗi thứ hai: ");
            string s2 = Console.ReadLine();
            bool result = IsRotation(s1, s2);
            if (result == true) Console.WriteLine("Chuỗi thứ hai là xoay vòng của chuỗi thứ nhất");
            else Console.WriteLine("Chuỗi thứ hai không phải là xoay vòng của chuỗi thứ nhất");
        }
    }
}