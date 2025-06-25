// Problems/Problem_2_2_ReturnKthToLast.cs
namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_2_ReturnKthToLast
    {
        /// <summary>
        /// Tìm phần tử thứ k đến cuối của một danh sách liên kết đơn.
        /// Time Complexity: O(N)
        /// Space Complexity: O(1)
        /// </summary>
        public Node? Solve(LinkedList list, int k)
        {
            if (list.Head == null || k <= 0) return null;

            Node? pointer1 = list.Head;
            Node? pointer2 = list.Head;

            // Di chuyển con trỏ2 k nút vào danh sách
            for (int i = 0; i < k; i++)
            {
                if (pointer2 == null) return null; // k lớn hơn độ dài của danh sách
                pointer2 = pointer2.Next;
            }

            // Di chuyển cả hai con trỏ với cùng tốc độ. Khi con trỏ2 chạm đến cuối, con trỏ1 sẽ ở phần tử thứ k đến cuối.
            while (pointer2 != null)
            {
                if (pointer1 != null)
                {
                    pointer1 = pointer1.Next;
                }
                pointer2 = pointer2.Next;
            }
            return pointer1;
        }
    }
}
