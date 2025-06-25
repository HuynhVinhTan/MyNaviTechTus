namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_3_DeleteMiddleNode
    {
        /// <summary>
        /// Xóa một nút ở giữa danh sách liên kết đơn, chỉ được cung cấp quyền truy cập vào nút đó.
        /// Phương thức này giả định nút cần xóa không phải là nút cuối cùng.
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        public bool Solve(Node nodeToDelete)
        {
            // Không thể xóa nút nếu nó là null hoặc nút cuối cùng trong danh sách bằng phương thức này
            if (nodeToDelete == null || nodeToDelete.Next == null)
            {
                return false;
            }

            Node nextNode = nodeToDelete.Next;
            nodeToDelete.Data = nextNode.Data;   // Sao chép dữ liệu từ nút tiếp theo
            nodeToDelete.Next = nextNode.Next;   // Bỏ qua nút tiếp theo
            return true;
        }
    }
}
