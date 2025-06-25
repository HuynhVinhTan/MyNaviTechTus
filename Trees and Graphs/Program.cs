using System;
using MyProject.Problems;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Chọn bài toán để chạy (nhập số):");
                Console.WriteLine("1. Route Between Nodes");
                Console.WriteLine("2. Minimal Tree");
                Console.WriteLine("3. List of Depths");
                Console.WriteLine("4. Check Balanced");
                Console.WriteLine("5. Validate BST");
                Console.WriteLine("6. Successor");
                Console.WriteLine("7. Build Order");
                Console.WriteLine("8. First Common Ancestor");
                Console.WriteLine("9. BST Sequences");
                Console.WriteLine("10. Check Subtree");
                Console.WriteLine("11. Random Node");
                Console.WriteLine("12. Paths with Sum");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.\n");
                    continue;
                }
                if (choice == 0) break;
                switch (choice)
                {
                    case 1: new B1().Run(); break;
                    case 2: new B2().Run(); break;
                    case 3: new B3().Run(); break;
                    case 4: new B4().Run(); break;
                    case 5: new B5().Run(); break;
                    case 6: new B6().Run(); break;
                    case 7: new B7().Run(); break;
                    case 8: new B8().Run(); break;
                    case 9: new B9().Run(); break;
                    case 10: new B10().Run(); break;
                    case 11: new B11().Run(); break;
                    case 12: new B12().Run(); break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.\n");
                        break;
                }
                Console.WriteLine("-----------------------------\n");
            }
        }
    }
} 