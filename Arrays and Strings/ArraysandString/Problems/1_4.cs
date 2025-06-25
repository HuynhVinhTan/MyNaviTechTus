using System;
using System.Collections.Generic;

namespace Problems
{
    public class B1_4
    {
        // Kiểm tra chuỗi có phải là hoán vị của một palindrome không
        public static bool IsPalindromePermutation(string str)
        {
            str = str.ToLower();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (c == ' ') continue;
                if (!charCount.ContainsKey(c))
                    charCount[c] = 0;
                charCount[c]++;
            }
            int oddCount = 0;
            foreach (var kvp in charCount)
            {
                if (kvp.Value % 2 != 0)
                    oddCount++;
                if (oddCount > 1)
                    return false;
            }
            return true;
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi: ");
            string input = Console.ReadLine();
            bool result = IsPalindromePermutation(input);
            Console.WriteLine($"Kết quả: {result}");
        }
    }
}