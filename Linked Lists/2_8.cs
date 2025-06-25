namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_8_LoopDetection
    {
        /// <summary>
        /// Cho một danh sách liên kết vòng, trả về nút ở đầu vòng lặp.
        /// Time Complexity: O(N)
        /// Space Complexity: O(1)
        /// </summary>
        public Node? Solve(LinkedList list)
        {
            if (list.Head == null) return null;

            Node? slow = list.Head;
            Node? fast = list.Head;

            // Giai đoạn 1: Tìm điểm va chạm (nếu có vòng lặp)
            // Con trỏ chậm di chuyển một bước, con trỏ nhanh di chuyển hai bước.
            while (fast != null && fast.Next != null)
            {
                if (slow != null && fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next.Next;
                    if (slow == fast) // Va chạm
                    {
                        break;
                    }
                }
            }

            // Nếu con trỏ nhanh đạt đến null, không có vòng lặp
            if (fast == null || fast.Next == null)
            {
                return null;
            }

            // Giai đoạn 2: Tìm điểm bắt đầu của vòng lặp
            // Di chuyển con trỏ chậm về Head. Giữ con trỏ nhanh ở điểm va chạm.
            // Di chuyển cả hai con trỏ mỗi lần một bước. Chúng sẽ gặp nhau ở đầu vòng lặp.
            slow = list.Head;
            while (slow != fast)
            {
                if (slow != null && fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }

            return fast; // Hoặc slow; cả hai đều trỏ đến đầu vòng lặp
        }
    }
}
