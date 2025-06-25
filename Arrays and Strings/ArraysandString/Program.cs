using System;
using Problems;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== MENU ===");
            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine($"{i}. Bài 1_{i}");
            }
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn bài muốn chạy: ");
            string input = Console.ReadLine();
            if (input == "0") break;
            switch (input)
            {
                case "1": B1_1.Run(); break;
                case "2": B1_2.Run(); break;
                case "3": B1_3.Run(); break;
                case "4": B1_4.Run(); break;
                case "5": B1_5.Run(); break;
                case "6": B1_6.Run(); break;
                case "7": B1_7.Run(); break;
                case "8": B1_8.Run(); break;
                case "9": B1_9.Run(); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }
            Console.WriteLine();
        }
    }
}