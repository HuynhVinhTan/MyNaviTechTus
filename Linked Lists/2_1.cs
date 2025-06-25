using System.Collections.Generic; // For HashSet

namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_1_RemoveDups
    {
        /// <summary>
        /// Loại bỏ các giá trị trùng lặp khỏi một danh sách liên kết chưa được sắp xếp bằng cách sử dụng bộ đệm tạm thời.
        /// Time Complexity: O(N)
        /// Space Complexity: O(N)
        /// </summary>
        public void RemoveDupsWithBuffer(LinkedList list)
        {
            if (list.Head == null) return;

            HashSet<int> seen = new HashSet<int>();
            Node? current = list.Head;
            Node? previous = null;

            while (current != null)
            {
                if (seen.Contains(current.Data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next; // Bỏ qua bản sao
                    }
                }
                else
                {
                    seen.Add(current.Data);
                    previous = current;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Loại bỏ các giá trị trùng lặp khỏi một danh sách liên kết chưa được sắp xếp mà không sử dụng bộ đệm tạm thời.
        /// Time Complexity: O(N^2)
        /// Space Complexity: O(1)
        /// </summary>
        public void RemoveDupsNoBuffer(LinkedList list)
        {
            if (list.Head == null) return;

            Node? current = list.Head;
            while (current != null)
            {
                Node runner = current; // Runner bắt đầu tại nút hiện tại
                while (runner.Next != null)
                {
                    if (runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next; // Bỏ qua bản sao
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
        }
    }
}
