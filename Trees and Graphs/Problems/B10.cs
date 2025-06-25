using System;

namespace MyProject.Problems
{
    public class B10
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

        // Tạo BST tối thiểu từ mảng đã sắp xếp (giống các bài trước)
        public TreeNode? CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            var node = new TreeNode(arr[mid]);
            node.Left = CreateMinimalBST(arr, start, mid - 1);
            node.Right = CreateMinimalBST(arr, mid + 1, end);
            return node;
        }

        // So sánh hai cây có giống hệt nhau không
        public bool MatchTree(TreeNode? t1, TreeNode? t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            if (t1.Value != t2.Value) return false;
            return MatchTree(t1.Left, t2.Left) && MatchTree(t1.Right, t2.Right);
        }

        // Kiểm tra T2 có là subtree của T1 không
        public bool IsSubtree(TreeNode? t1, TreeNode? t2)
        {
            if (t2 == null) return true; // Cây rỗng luôn là subtree
            if (t1 == null) return false;
            if (t1.Value == t2.Value && MatchTree(t1, t2)) return true;
            return IsSubtree(t1.Left, t2) || IsSubtree(t1.Right, t2);
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp cho T1, cách nhau bởi dấu cách:");
            var input1 = Console.ReadLine();
            var arr1 = Array.ConvertAll(input1!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var t1 = CreateMinimalBST(arr1, 0, arr1.Length - 1);
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp cho T2, cách nhau bởi dấu cách:");
            var input2 = Console.ReadLine();
            var arr2 = Array.ConvertAll(input2!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var t2 = CreateMinimalBST(arr2, 0, arr2.Length - 1);
            bool isSub = IsSubtree(t1, t2);
            Console.WriteLine(isSub ? "T2 là subtree của T1." : "T2 không phải là subtree của T1.");
        }
    }
} 