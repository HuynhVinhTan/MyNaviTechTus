
namespace LinkedListAlgorithms
{
    /// <summary>
    /// Đại diện cho một nút trong danh sách liên kết đơn.
    /// </summary>
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
