using System;

namespace Problems
{
    public class B1_1
    {
        // Kiểm tra uniqueness không dùng cấu trúc dữ liệu bổ sung
        public static bool IsUniqueChars(string str)
        {
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (str[i] == str[j])
                        return false;
                }
            }
            return true;
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi cần kiểm tra: ");
            string input = Console.ReadLine();
            if (IsUniqueChars(input))
                Console.WriteLine("Chuỗi có tất cả các ký tự là duy nhất.");
            else
                Console.WriteLine("Chuỗi có ký tự bị lặp lại.");
        }
    }
}