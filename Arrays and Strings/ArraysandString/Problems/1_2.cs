using System;

namespace Problems
{
    public class B1_2
    {
        // Kiểm tra hai chuỗi có phải là hoán vị của nhau không
        public static bool CheckPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            char[] arr1 = s1.ToCharArray();
            char[] arr2 = s2.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }

        public static void Run()
        {
            Console.Write("Nhập chuỗi thứ nhất: ");
            string s1 = Console.ReadLine();
            Console.Write("Nhập chuỗi thứ hai: ");
            string s2 = Console.ReadLine();
            if (CheckPermutation(s1, s2))
                Console.WriteLine("Hai chuỗi là hoán vị của nhau.");
            else
                Console.WriteLine("Hai chuỗi KHÔNG phải là hoán vị của nhau.");
        }
    }
}