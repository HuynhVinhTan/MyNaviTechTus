using System;

namespace MyProject.Problems
{
    public class B6
    {
        // Định nghĩa node của cây nhị phân có parent
        public class TreeNode
        {
            public int Value;
            public TreeNode? Left;
            public TreeNode? Right;
            public TreeNode? Parent;
            public TreeNode(int value)
            {
                Value = value;
            }
        }

        // Tạo BST tối thiểu từ mảng đã sắp xếp, có parent
        public TreeNode? CreateMinimalBST(int[] arr, int start, int end, TreeNode? parent)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            var node = new TreeNode(arr[mid]);
            node.Parent = parent;
            node.Left = CreateMinimalBST(arr, start, mid - 1, node);
            node.Right = CreateMinimalBST(arr, mid + 1, end, node);
            return node;
        }

        // Tìm node theo giá trị
        public TreeNode? Find(TreeNode? root, int value)
        {
            if (root == null) return null;
            if (root.Value == value) return root;
            if (value < root.Value) return Find(root.Left, value);
            return Find(root.Right, value);
        }

        // Tìm node kế tiếp (in-order successor)
        public TreeNode? InOrderSuccessor(TreeNode node)
        {
            if (node.Right != null)
            {
                // Successor là node trái nhất của cây con phải
                var curr = node.Right;
                while (curr.Left != null) curr = curr.Left;
                return curr;
            }
            // Ngược lên cha cho đến khi node là con trái
            var parent = node.Parent;
            var child = node;
            while (parent != null && parent.Right == child)
            {
                child = parent;
                parent = parent.Parent;
            }
            return parent;
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo BST tối thiểu):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1, null);
            Console.WriteLine("Nhập giá trị node cần tìm successor:");
            int x = int.Parse(Console.ReadLine()!);
            var node = Find(root, x);
            if (node == null)
            {
                Console.WriteLine($"Không tìm thấy node có giá trị {x} trong cây.");
                return;
            }
            var succ = InOrderSuccessor(node);
            if (succ == null)
                Console.WriteLine($"Node {x} không có successor (là node lớn nhất).");
            else
                Console.WriteLine($"Successor của node {x} là: {succ.Value}");
        }
    }
} 