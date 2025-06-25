using System;

namespace MyProject.Problems
{
    public class B2
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

        // Hàm tạo BST tối thiểu từ mảng đã sắp xếp
        public TreeNode? CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            var node = new TreeNode(arr[mid]);
            node.Left = CreateMinimalBST(arr, start, mid - 1);
            node.Right = CreateMinimalBST(arr, mid + 1, end);
            return node;
        }

        // Hàm in cây theo thứ tự giữa (in-order)
        public void PrintInOrder(TreeNode? node)
        {
            if (node == null) return;
            PrintInOrder(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrder(node.Right);
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách:");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            Console.WriteLine("Cây nhị phân tìm kiếm tối thiểu (in-order):");
            PrintInOrder(root);
            Console.WriteLine();
        }
    }
} 