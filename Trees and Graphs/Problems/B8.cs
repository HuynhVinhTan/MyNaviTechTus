using System;

namespace MyProject.Problems
{
    public class B8
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

        // Tạo cây nhị phân tối thiểu từ mảng đã sắp xếp (giống các bài trước)
        public TreeNode? CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            var node = new TreeNode(arr[mid]);
            node.Left = CreateMinimalBST(arr, start, mid - 1);
            node.Right = CreateMinimalBST(arr, mid + 1, end);
            return node;
        }

        // Tìm node theo giá trị
        public TreeNode? Find(TreeNode? root, int value)
        {
            if (root == null) return null;
            if (root.Value == value) return root;
            var left = Find(root.Left, value);
            if (left != null) return left;
            return Find(root.Right, value);
        }

        // Tìm tổ tiên chung đầu tiên
        public TreeNode? FirstCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
        {
            if (root == null || root == p || root == q) return root;
            var left = FirstCommonAncestor(root.Left, p, q);
            var right = FirstCommonAncestor(root.Right, p, q);
            if (left != null && right != null) return root;
            return left ?? right;
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo cây nhị phân):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            Console.WriteLine("Nhập giá trị node thứ nhất:");
            int x = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhập giá trị node thứ hai:");
            int y = int.Parse(Console.ReadLine()!);
            var node1 = Find(root, x);
            var node2 = Find(root, y);
            if (node1 == null || node2 == null)
            {
                Console.WriteLine("Không tìm thấy một hoặc cả hai node trong cây.");
                return;
            }
            var ancestor = FirstCommonAncestor(root, node1, node2);
            if (ancestor == null)
                Console.WriteLine("Không có tổ tiên chung.");
            else
                Console.WriteLine($"Tổ tiên chung đầu tiên của {x} và {y} là: {ancestor.Value}");
        }
    }
} 