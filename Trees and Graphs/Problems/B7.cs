using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B7
    {
        // Topological Sort để tìm build order
        public List<string>? FindBuildOrder(List<string> projects, List<(string, string)> dependencies)
        {
            var adj = new Dictionary<string, List<string>>();
            var indegree = new Dictionary<string, int>();
            foreach (var p in projects)
            {
                adj[p] = new List<string>();
                indegree[p] = 0;
            }
            foreach (var (pre, post) in dependencies)
            {
                adj[pre].Add(post);
                indegree[post]++;
            }
            var queue = new Queue<string>();
            foreach (var p in projects)
                if (indegree[p] == 0) queue.Enqueue(p);
            var order = new List<string>();
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                order.Add(curr);
                foreach (var next in adj[curr])
                {
                    indegree[next]--;
                    if (indegree[next] == 0) queue.Enqueue(next);
                }
            }
            if (order.Count != projects.Count) return null; // Có chu trình
            return order;
        }

        public void Run()
        {
            Console.WriteLine("Nhập danh sách project, cách nhau bởi dấu phẩy (ví dụ: a,b,c,d,e,f):");
            var projects = new List<string>(Console.ReadLine()!.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            Console.WriteLine("Nhập số lượng dependency:");
            int m = int.Parse(Console.ReadLine()!);
            var dependencies = new List<(string, string)>();
            Console.WriteLine("Nhập các dependency dạng (pre post), mỗi dòng 2 ký tự cách nhau bởi dấu cách (ví dụ: a d):");
            for (int i = 0; i < m; i++)
            {
                var parts = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                dependencies.Add((parts[0], parts[1]));
            }
            var order = FindBuildOrder(projects, dependencies);
            if (order == null)
                Console.WriteLine("Không tồn tại build order hợp lệ (có chu trình phụ thuộc).");
            else
                Console.WriteLine("Build order: " + string.Join(", ", order));
        }
    }
} 