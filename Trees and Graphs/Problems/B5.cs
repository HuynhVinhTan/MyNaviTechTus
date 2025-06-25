using System;

namespace MyProject.Problems
{
    public class B5
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

        // Kiểm tra cây có phải là BST không
        public bool IsValidBST(TreeNode? root)
        {
            return IsValidBST(root, int.MinValue, int.MaxValue);
        }

        private bool IsValidBST(TreeNode? node, int min, int max)
        {
            if (node == null) return true;
            if (node.Value <= min || node.Value >= max) return false;
            return IsValidBST(node.Left, min, node.Value) && IsValidBST(node.Right, node.Value, max);
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo BST tối thiểu):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            bool isBST = IsValidBST(root);
            Console.WriteLine(isBST ? "Cây là Binary Search Tree (BST)." : "Cây không phải là Binary Search Tree (BST).");
        }
    }
} 