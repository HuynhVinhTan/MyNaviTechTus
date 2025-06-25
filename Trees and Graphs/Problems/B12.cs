using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B12
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

        // Đếm số đường đi có tổng bằng target
        public int PathSum(TreeNode? root, int targetSum)
        {
            if (root == null) return 0;
            return PathSumFrom(root, targetSum) + PathSum(root.Left, targetSum) + PathSum(root.Right, targetSum);
        }

        // Đếm số đường đi bắt đầu từ node hiện tại
        private int PathSumFrom(TreeNode? node, int sum)
        {
            if (node == null) return 0;
            int count = (node.Value == sum) ? 1 : 0;
            count += PathSumFrom(node.Left, sum - node.Value);
            count += PathSumFrom(node.Right, sum - node.Value);
            return count;
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo cây nhị phân):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            Console.WriteLine("Nhập tổng cần tìm:");
            int target = int.Parse(Console.ReadLine()!);
            int count = PathSum(root, target);
            Console.WriteLine($"Số đường đi có tổng bằng {target}: {count}");
        }
    }
} 