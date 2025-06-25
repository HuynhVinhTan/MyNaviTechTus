// Program.cs
#nullable enable // Bật kiểm tra nullable cho tệp này

using System;
using LinkedListAlgorithms.Problems; // Namespace cho các lớp giải thuật

namespace LinkedListAlgorithms
{
    /// <summary>
    /// Lớp chương trình chính để kiểm tra các thuật toán danh sách liên kết.
    /// </summary>
    public class Program
    {
        // Khởi tạo các lớp giải thuật một lần
        private static readonly Problem_2_1_RemoveDups removeDupsSolver = new Problem_2_1_RemoveDups();
        private static readonly Problem_2_2_ReturnKthToLast kthToLastSolver = new Problem_2_2_ReturnKthToLast();
        private static readonly Problem_2_3_DeleteMiddleNode deleteMiddleNodeSolver = new Problem_2_3_DeleteMiddleNode();
        private static readonly Problem_2_4_Partition partitionSolver = new Problem_2_4_Partition();
        private static readonly Problem_2_5_SumLists sumListsSolver = new Problem_2_5_SumLists();
        private static readonly Problem_2_6_Palindrome palindromeSolver = new Problem_2_6_Palindrome();
        private static readonly Problem_2_7_Intersection intersectionSolver = new Problem_2_7_Intersection();
        private static readonly Problem_2_8_LoopDetection loopDetectionSolver = new Problem_2_8_LoopDetection();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChọn bài toán để chạy (nhập số):");
                Console.WriteLine("1. Bài 2.1: Remove Duplicates");
                Console.WriteLine("2. Bài 2.2: Return Kth to Last");
                Console.WriteLine("3. Bài 2.3: Delete Middle Node");
                Console.WriteLine("4. Bài 2.4: Partition");
                Console.WriteLine("5. Bài 2.5: Sum Lists");
                Console.WriteLine("6. Bài 2.6: Palindrome");
                Console.WriteLine("7. Bài 2.7: Intersection");
                Console.WriteLine("8. Bài 2.8: Loop Detection");
                Console.WriteLine("9. Chạy tất cả các bài");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TestProblem_2_1();
                        break;
                    case "2":
                        TestProblem_2_2();
                        break;
                    case "3":
                        TestProblem_2_3();
                        break;
                    case "4":
                        TestProblem_2_4();
                        break;
                    case "5":
                        TestProblem_2_5();
                        break;
                    case "6":
                        TestProblem_2_6();
                        break;
                    case "7":
                        TestProblem_2_7();
                        break;
                    case "8":
                        TestProblem_2_8();
                        break;
                    case "9":
                        RunAllTests();
                        break;
                    case "0":
                        Console.WriteLine("Đang thoát...");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
                Console.WriteLine("\n----------------------------------------");
            }
        }

        private static void RunAllTests()
        {
            TestProblem_2_1();
            TestProblem_2_2();
            TestProblem_2_3();
            TestProblem_2_4();
            TestProblem_2_5();
            TestProblem_2_6();
            TestProblem_2_7();
            TestProblem_2_8();
        }

        private static void TestProblem_2_1()
        {
            Console.WriteLine("\n--- 2.1 Remove Duplicates ---");
            LinkedList listDups1 = new LinkedList();
            listDups1.Append(1); listDups1.Append(2); listDups1.Append(3);
            listDups1.Append(2); listDups1.Append(4); listDups1.Append(1);
            Console.Write("Original for RemoveDupsWithBuffer: "); listDups1.PrintList();
            removeDupsSolver.RemoveDupsWithBuffer(listDups1);
            Console.Write("After RemoveDupsWithBuffer:      "); listDups1.PrintList();

            LinkedList listDups2 = new LinkedList();
            listDups2.Append(1); listDups2.Append(5); listDups2.Append(1);
            listDups2.Append(5); listDups2.Append(2); listDups2.Append(5);
            Console.Write("Original for RemoveDupsNoBuffer: "); listDups2.PrintList();
            removeDupsSolver.RemoveDupsNoBuffer(listDups2);
            Console.Write("After RemoveDupsNoBuffer:        "); listDups2.PrintList();
        }

        private static void TestProblem_2_2()
        {
            Console.WriteLine("\n--- 2.2 Return Kth to Last ---");
            LinkedList listKth = new LinkedList();
            listKth.Append(10); listKth.Append(20); listKth.Append(30);
            listKth.Append(40); listKth.Append(50);
            Console.Write("List for Kth: "); listKth.PrintList();
            int kVal = 2;
            Node? kthNode = kthToLastSolver.Solve(listKth, kVal);
            Console.WriteLine($"{kVal}th to last element: " + (kthNode?.Data.ToString() ?? "null"));
            kVal = 5;
            kthNode = kthToLastSolver.Solve(listKth, kVal);
            Console.WriteLine($"{kVal}th to last element: " + (kthNode?.Data.ToString() ?? "null"));
            kVal = 1;
            kthNode = kthToLastSolver.Solve(listKth, kVal);
            Console.WriteLine($"{kVal}st to last element: " + (kthNode?.Data.ToString() ?? "null"));
            kVal = 6;
            kthNode = kthToLastSolver.Solve(listKth, kVal);
            Console.WriteLine($"{kVal}th to last element: " + (kthNode?.Data.ToString() ?? "null"));
        }

        private static void TestProblem_2_3()
        {
            Console.WriteLine("\n--- 2.3 Delete Middle Node ---");
            LinkedList listDel = new LinkedList();
            Node nodeA = new Node('a'); Node nodeB = new Node('b'); Node nodeC = new Node('c');
            Node nodeD = new Node('d'); Node nodeE = new Node('e'); Node nodeF = new Node('f');
            listDel.Head = nodeA; nodeA.Next = nodeB; nodeB.Next = nodeC; nodeC.Next = nodeD;
            nodeD.Next = nodeE; nodeE.Next = nodeF;
            Console.Write("Original for DeleteMiddleNode: "); listDel.PrintListAsChars();
            bool deleted = deleteMiddleNodeSolver.Solve(nodeC);
            Console.WriteLine($"Node 'c' deleted: {deleted}");
            Console.Write("After deleting 'c':            "); listDel.PrintListAsChars();

            LinkedList listDelFail = new LinkedList();
            Node nodeX = new Node('x'); Node nodeY = new Node('y');
            listDelFail.Head = nodeX; nodeX.Next = nodeY;
            Console.Write("List for delete fail test: "); listDelFail.PrintListAsChars();
            deleted = deleteMiddleNodeSolver.Solve(nodeY);
            Console.WriteLine($"Node 'y' (last node) deleted: {deleted}");
            Console.Write("List after attempting to delete 'y': "); listDelFail.PrintListAsChars();
        }

        private static void TestProblem_2_4()
        {
            Console.WriteLine("\n--- 2.4 Partition ---");
            LinkedList listPart = new LinkedList();
            listPart.Append(3); listPart.Append(5); listPart.Append(8); listPart.Append(5);
            listPart.Append(10); listPart.Append(2); listPart.Append(1);
            Console.Write("Original for Partition (x=5): "); listPart.PrintList();
            int partitionVal = 5;
            LinkedList partitionedList = partitionSolver.Solve(listPart, partitionVal);
            Console.Write($"After PartitionStable around {partitionVal}: "); partitionedList.PrintList();

            LinkedList listPart2 = new LinkedList();
            listPart2.Append(10); listPart2.Append(2); listPart2.Append(8); listPart2.Append(1); listPart2.Append(5);
            Console.Write("Original for Partition (x=5): "); listPart2.PrintList();
            partitionedList = partitionSolver.Solve(listPart2, 5);
            Console.Write($"After PartitionStable around {5}: "); partitionedList.PrintList();
        }

        private static void TestProblem_2_5()
        {
            Console.WriteLine("\n--- 2.5 Sum Lists ---");
            LinkedList num1Rev = new LinkedList(); num1Rev.Append(7); num1Rev.Append(1); num1Rev.Append(6);
            LinkedList num2Rev = new LinkedList(); num2Rev.Append(5); num2Rev.Append(9); num2Rev.Append(2);
            Console.Write("Num1 (617 reversed): "); num1Rev.PrintList();
            Console.Write("Num2 (295 reversed): "); num2Rev.PrintList();
            LinkedList sumRev = sumListsSolver.SumListsReverseOrder(num1Rev, num2Rev);
            Console.Write("Sum (912 reversed):  "); sumRev.PrintList();

            LinkedList num1Fwd = new LinkedList(); num1Fwd.Append(6); num1Fwd.Append(1); num1Fwd.Append(7);
            LinkedList num2Fwd = new LinkedList(); num2Fwd.Append(2); num2Fwd.Append(9); num2Fwd.Append(5);
            Console.Write("Num1 (617 forward): "); num1Fwd.PrintList();
            Console.Write("Num2 (295 forward): "); num2Fwd.PrintList();
            LinkedList sumFwd = sumListsSolver.SumListsForwardOrder(num1Fwd, num2Fwd);
            Console.Write("Sum (912 forward):  "); sumFwd.PrintList();
            
            LinkedList num3Fwd = new LinkedList(); num3Fwd.Append(9); num3Fwd.Append(9);
            LinkedList num4Fwd = new LinkedList(); num4Fwd.Append(1);
            Console.Write("Num3 (99 forward): "); num3Fwd.PrintList();
            Console.Write("Num4 (1 forward):  "); num4Fwd.PrintList();
            LinkedList sumFwd2 = sumListsSolver.SumListsForwardOrder(num3Fwd, num4Fwd);
            Console.Write("Sum (100 forward): "); sumFwd2.PrintList();
        }

        private static void TestProblem_2_6()
        {
            Console.WriteLine("\n--- 2.6 Palindrome ---");
            LinkedList pList1 = new LinkedList();
            pList1.Append(0); pList1.Append(1); pList1.Append(2); pList1.Append(1); pList1.Append(0);
            Console.Write("List: "); pList1.PrintList();
            Console.WriteLine($"Is Palindrome (Reverse method): {palindromeSolver.IsPalindromeReverseAndCompare(pList1)}");
            Console.WriteLine($"Is Palindrome (Stack method):   {palindromeSolver.IsPalindromeStack(pList1)}");

            LinkedList pList2 = new LinkedList();
            pList2.Append(0); pList2.Append(1); pList2.Append(2); pList2.Append(2); pList2.Append(1); pList2.Append(0);
            Console.Write("List: "); pList2.PrintList();
            Console.WriteLine($"Is Palindrome (Reverse method): {palindromeSolver.IsPalindromeReverseAndCompare(pList2)}");
            Console.WriteLine($"Is Palindrome (Stack method):   {palindromeSolver.IsPalindromeStack(pList2)}");

            LinkedList pList3 = new LinkedList();
            pList3.Append(0); pList3.Append(1); pList3.Append(3); pList3.Append(1); pList3.Append(0); pList3.Append(5);
            Console.Write("List: "); pList3.PrintList();
            Console.WriteLine($"Is Palindrome (Reverse method): {palindromeSolver.IsPalindromeReverseAndCompare(pList3)}");
            Console.WriteLine($"Is Palindrome (Stack method):   {palindromeSolver.IsPalindromeStack(pList3)}");
        }

        private static void TestProblem_2_7()
        {
            Console.WriteLine("\n--- 2.7 Intersection ---");
            LinkedList listIntA = new LinkedList();
            LinkedList listIntB = new LinkedList();
            Node commonNode1 = new Node(70);
            Node commonNode2 = new Node(80);
            Node commonNode3 = new Node(90);
            commonNode1.Next = commonNode2;
            commonNode2.Next = commonNode3;

            listIntA.Append(10); listIntA.Append(20);
            listIntA.AppendNode(commonNode1);

            listIntB.Append(30); listIntB.Append(40); listIntB.Append(50);
            listIntB.AppendNode(commonNode1);

            Console.Write("List A for Intersection: "); listIntA.PrintList();
            Console.Write("List B for Intersection: "); listIntB.PrintList();
            Node? intersection = intersectionSolver.Solve(listIntA, listIntB);
            Console.WriteLine("Intersection Node Data: " + (intersection?.Data.ToString() ?? "null"));

            LinkedList listNoIntA = new LinkedList(); listNoIntA.Append(1); listNoIntA.Append(2);
            LinkedList listNoIntB = new LinkedList(); listNoIntB.Append(3); listNoIntB.Append(4);
            Console.Write("List NoInt A: "); listNoIntA.PrintList();
            Console.Write("List NoInt B: "); listNoIntB.PrintList();
            intersection = intersectionSolver.Solve(listNoIntA, listNoIntB);
            Console.WriteLine("Intersection Node Data (No Intersection): " + (intersection?.Data.ToString() ?? "null"));
        }

        private static void TestProblem_2_8()
        {
            Console.WriteLine("\n--- 2.8 Loop Detection ---");
            LinkedList listLoop = new LinkedList();
            Node loopNodeA = new Node('A'); Node loopNodeB = new Node('B'); Node loopNodeC = new Node('C');
            Node loopNodeD = new Node('D'); Node loopNodeE = new Node('E');
            listLoop.Head = loopNodeA;
            loopNodeA.Next = loopNodeB; loopNodeB.Next = loopNodeC; loopNodeC.Next = loopNodeD;
            loopNodeD.Next = loopNodeE;
            loopNodeE.Next = loopNodeC;

            Console.WriteLine("Loop List (A->B->C->D->E->C...): Visual check needed for structure.");
            Node? loopStartNode = loopDetectionSolver.Solve(listLoop);
            Console.WriteLine("Loop Start Node Data: " + (loopStartNode != null ? ((char)loopStartNode.Data).ToString() : "null"));

            LinkedList listNoLoop = new LinkedList();
            listNoLoop.Append(100); listNoLoop.Append(200); listNoLoop.Append(300);
            Console.Write("No Loop List: "); listNoLoop.PrintList();
            loopStartNode = loopDetectionSolver.Solve(listNoLoop);
            Console.WriteLine("Loop Start Node Data (No Loop): " + (loopStartNode?.Data.ToString() ?? "null"));
        }
    }
}
