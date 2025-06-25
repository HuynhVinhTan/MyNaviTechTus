using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B3
    {
        // Định nghĩa node của cây nhị phân
        public class TreeNode
        {
            public int Value;
            public TreeNode? Left;
            public TreeNode? Right;
            public TreeNode(int value)
            {
                Value = value;
            }
        }

        // Tạo BST tối thiểu từ mảng đã sắp xếp (tái sử dụng từ B2)
        public TreeNode? CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            var node = new TreeNode(arr[mid]);
            node.Left = CreateMinimalBST(arr, start, mid - 1);
            node.Right = CreateMinimalBST(arr, mid + 1, end);
            return node;
        }

        // Tạo danh sách các linked list cho mỗi tầng
        public List<LinkedList<TreeNode>> ListOfDepths(TreeNode? root)
        {
            var result = new List<LinkedList<TreeNode>>();
            if (root == null) return result;
            var current = new LinkedList<TreeNode>();
            current.AddLast(root);
            while (current.Count > 0)
            {
                result.Add(current);
                var parents = current;
                current = new LinkedList<TreeNode>();
                foreach (var node in parents)
                {
                    if (node.Left != null) current.AddLast(node.Left);
                    if (node.Right != null) current.AddLast(node.Right);
                }
            }
            return result;
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo BST tối thiểu):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            var lists = ListOfDepths(root);
            Console.WriteLine("Các node ở mỗi tầng:");
            for (int d = 0; d < lists.Count; d++)
            {
                Console.Write($"Tầng {d}: ");
                foreach (var node in lists[d])
                {
                    Console.Write(node.Value + " ");
                }
                Console.WriteLine();
            }
        }
    }
} 