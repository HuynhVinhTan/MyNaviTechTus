using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B9
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

        // Tạo BST từ mảng theo thứ tự chèn (dành cho test tự do)
        public TreeNode? Insert(TreeNode? root, int value)
        {
            if (root == null) return new TreeNode(value);
            if (value < root.Value) root.Left = Insert(root.Left, value);
            else root.Right = Insert(root.Right, value);
            return root;
        }

        // Hàm chính để sinh tất cả các sequence
        public List<List<int>> BSTSequences(TreeNode? node)
        {
            var result = new List<List<int>>();
            if (node == null)
            {
                result.Add(new List<int>());
                return result;
            }
            var prefix = new List<int> { node.Value };
            var leftSeq = BSTSequences(node.Left);
            var rightSeq = BSTSequences(node.Right);
            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    var weaved = new List<List<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }
            }
            return result;
        }

        // Trộn hai list giữ nguyên thứ tự bên trong mỗi list
        private void WeaveLists(List<int> first, List<int> second, List<List<int>> results, List<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                var res = new List<int>(prefix);
                res.AddRange(first);
                res.AddRange(second);
                results.Add(res);
                return;
            }
            // Lấy từ first
            int headFirst = first[0];
            first.RemoveAt(0);
            prefix.Add(headFirst);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            first.Insert(0, headFirst);
            // Lấy từ second
            int headSecond = second[0];
            second.RemoveAt(0);
            prefix.Add(headSecond);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            second.Insert(0, headSecond);
        }

        public void Run()
        {
            Console.WriteLine("Nhập mảng số nguyên đã sắp xếp, cách nhau bởi dấu cách (dùng để tạo BST tối thiểu):");
            var input = Console.ReadLine();
            var arr = Array.ConvertAll(input!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var root = CreateMinimalBST(arr, 0, arr.Length - 1);
            var sequences = BSTSequences(root);
            Console.WriteLine("Các mảng có thể tạo ra BST này:");
            foreach (var seq in sequences)
            {
                Console.WriteLine("{" + string.Join(", ", seq) + "}");
            }
        }
    }
} 