using System; // For Math.Abs

namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_7_Intersection
    {
        /// <summary>
        /// Xác định xem hai danh sách liên kết đơn có giao nhau hay không và trả về nút giao nhau.
        /// Giao điểm được định nghĩa bằng tham chiếu, không phải giá trị.
        /// Time Complexity: O(N+M)
        /// Space Complexity: O(1)
        /// </summary>
        public Node? Solve(LinkedList list1, LinkedList list2)
        {
            if (list1.Head == null || list2.Head == null) return null;

            // 1. Lấy đuôi và kích thước của cả hai danh sách
            Result tailAndSize1 = GetTailAndSize(list1.Head);
            Result tailAndSize2 = GetTailAndSize(list2.Head);

            // 2. Nếu các đuôi khác nhau, chúng không giao nhau theo tham chiếu
            if (tailAndSize1.TailNode != tailAndSize2.TailNode)
            {
                return null;
            }

            // 3. Đặt các con trỏ đến đầu mỗi danh sách
            Node? shorter = tailAndSize1.Size < tailAndSize2.Size ? list1.Head : list2.Head;
            Node? longer = tailAndSize1.Size < tailAndSize2.Size ? list2.Head : list1.Head;

            // 4. Di chuyển con trỏ cho danh sách dài hơn theo chênh lệch độ dài
            longer = GetKthNode(longer, Math.Abs(tailAndSize1.Size - tailAndSize2.Size));

            // 5. Di chuyển cả hai con trỏ cho đến khi chúng va chạm. Đó là giao điểm.
            while (shorter != longer)
            {
                if (shorter != null && longer != null)
                {
                    shorter = shorter.Next;
                    longer = longer.Next;
                }
            }
            return longer; // Hoặc shorter, chúng giống nhau bây giờ
        }

        private class Result // Lớp nội bộ để trả về nhiều giá trị
        {
            public Node? TailNode { get; }
            public int Size { get; }
            public Result(Node? tail, int size)
            {
                TailNode = tail;
                Size = size;
            }
        }

        private Result GetTailAndSize(Node head)
        {
            if (head == null) return new Result(null, 0);
            int size = 1;
            Node current = head;
            while (current.Next != null)
            {
                size++;
                current = current.Next;
            }
            return new Result(current, size); // current bây giờ là đuôi
        }

        private Node? GetKthNode(Node head, int k)
        {
            Node? current = head;
            while (k > 0 && current != null)
            {
                current = current.Next;
                k--;
            }
            return current;
        }
    }
}
