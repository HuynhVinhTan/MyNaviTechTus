
using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B11
    {
        public class TreeNode
        {
            public int Value;
            public TreeNode? Left;
            public TreeNode? Right;
            public int Size = 1; // Số node trong subtree này (bao gồm cả node hiện tại)
            public TreeNode(int value)
            {
                Value = value;
            }
        }

        public class BinaryTree
        {
            public TreeNode? Root;
            private Random rand = new Random();

            public void Insert(int value)
            {
                Root = Insert(Root, value);
            }

            private TreeNode Insert(TreeNode? node, int value)
            {
                if (node == null) return new TreeNode(value);
                if (value < node.Value)
                    node.Left = Insert(node.Left, value);
                else
                    node.Right = Insert(node.Right, value);
                node.Size = 1 + GetSize(node.Left) + GetSize(node.Right);
                return node;
            }

            public TreeNode? Find(int value)
            {
                var curr = Root;
                while (curr != null)
                {
                    if (curr.Value == value) return curr;
                    curr = value < curr.Value ? curr.Left : curr.Right;
                }
                return null;
            }

            public void Delete(int value)
            {
                Root = Delete(Root, value);
            }

            private TreeNode? Delete(TreeNode? node, int value)
            {
                if (node == null) return null;
                if (value < node.Value)
                    node.Left = Delete(node.Left, value);
                else if (value > node.Value)
                    node.Right = Delete(node.Right, value);
                else
                {
                    if (node.Left == null) return node.Right;
                    if (node.Right == null) return node.Left;
                    // Tìm node nhỏ nhất bên phải
                    var minLarger = node.Right;
                    while (minLarger.Left != null) minLarger = minLarger.Left;
                    node.Value = minLarger.Value;
                    node.Right = Delete(node.Right, minLarger.Value);
                }
                node.Size = 1 + GetSize(node.Left) + GetSize(node.Right);
                return node;
            }

            private int GetSize(TreeNode? node) => node?.Size ?? 0;

            public TreeNode? GetRandomNode()
            {
                if (Root == null) return null;
                int idx = rand.Next(GetSize(Root)); // 0..size-1
                return GetIthNode(Root, idx);
            }

            private TreeNode? GetIthNode(TreeNode node, int i)
            {
                int leftSize = GetSize(node.Left);
                if (i < leftSize) return GetIthNode(node.Left!, i);
                else if (i == leftSize) return node;
                else return GetIthNode(node.Right!, i - leftSize - 1);
            }
        }

        public void Run()
        {
            var tree = new BinaryTree();
            Console.WriteLine("Nhập các số để chèn vào cây, cách nhau bởi dấu cách:");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            foreach (var x in arr) tree.Insert(x);
            Console.WriteLine("Chọn chức năng: 1. Insert 2. Find 3. Delete 4. GetRandomNode 0. Thoát");
            while (true)
            {
                Console.Write("Lựa chọn: ");
                var choice = Console.ReadLine();
                if (choice == "0") break;
                if (choice == "1")
                {
                    Console.Write("Nhập số cần chèn: ");
                    int x = int.Parse(Console.ReadLine()!);
                    tree.Insert(x);
                    Console.WriteLine("Đã chèn.");
                }
                else if (choice == "2")
                {
                    Console.Write("Nhập số cần tìm: ");
                    int x = int.Parse(Console.ReadLine()!);
                    var found = tree.Find(x);
                    Console.WriteLine(found != null ? $"Tìm thấy node {x}." : "Không tìm thấy.");
                }
                else if (choice == "3")
                {
                    Console.Write("Nhập số cần xóa: ");
                    int x = int.Parse(Console.ReadLine()!);
                    tree.Delete(x);
                    Console.WriteLine("Đã xóa.");
                }
                else if (choice == "4")
                {
                    var node = tree.GetRandomNode();
                    Console.WriteLine(node != null ? $"Node ngẫu nhiên: {node.Value}" : "Cây rỗng.");
                }
            }
        }
    }
} 