using System;

namespace MyProject.Problems
{
    public class B4
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

        // Kiểm tra cây có cân bằng không
        public bool IsBalanced(TreeNode? root)
        {
            return CheckHeight(root) != -1;
        }

        // Trả về chiều cao nếu cân bằng, -1 nếu không cân bằng
        private int CheckHeight(TreeNode? node)
        {
            if (node == null) return 0;
            int leftHeight = CheckHeight(node.Left);
            if (leftHeight == -1) return -1;
            int rightHeight = CheckHeight(node.Right);
            if (rightHeight == -1) return -1;
            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo BST tối thiểu):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            bool balanced = IsBalanced(root);
            Console.WriteLine(balanced ? "Cây nhị phân cân bằng." : "Cây nhị phân không cân bằng.");
        }
    }
} 