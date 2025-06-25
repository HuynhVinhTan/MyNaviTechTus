using System;
using System.Collections.Generic;

namespace MyProject.Problems
{
    public class B1
    {
        // Định nghĩa đồ thị dạng danh sách kề
        public class Graph
        {
            private readonly Dictionary<int, List<int>> adj = new();

            public void AddEdge(int from, int to)
            {
                if (!adj.ContainsKey(from))
                    adj[from] = new List<int>();
                adj[from].Add(to);
            }

            public bool HasRoute(int start, int end)
            {
                if (start == end) return true;
                var visited = new HashSet<int>();
                var queue = new Queue<int>();
                queue.Enqueue(start);
                visited.Add(start);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (!adj.ContainsKey(node)) continue;
                    foreach (var neighbor in adj[node])
                    {
                        if (neighbor == end) return true;
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
                return false;
            }
        }

        public void Run()
        {
            Console.WriteLine("Nhập số lượng cạnh của đồ thị:");
            int m = int.Parse(Console.ReadLine()!);
            var graph = new Graph();

            Console.WriteLine("Nhập các cạnh (from to), mỗi cạnh trên 1 dòng:");
            for (int i = 0; i < m; i++)
            {
                var parts = Console.ReadLine()!.Split();
                int from = int.Parse(parts[0]);
                int to = int.Parse(parts[1]);
                graph.AddEdge(from, to);
            }

            Console.WriteLine("Nhập hai node cần kiểm tra đường đi (start end):");
            var check = Console.ReadLine()!.Split();
            int start = int.Parse(check[0]);
            int end = int.Parse(check[1]);

            bool hasRoute = graph.HasRoute(start, end);
            Console.WriteLine(hasRoute
                ? $"Có đường đi từ {start} đến {end}."
                : $"Không có đường đi từ {start} đến {end}.");
        }
    }
} 