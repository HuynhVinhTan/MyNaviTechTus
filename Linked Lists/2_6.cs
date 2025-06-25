using System.Collections.Generic; // For Stack

namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_6_Palindrome
    {
        /// <summary>
        /// Kiểm tra xem một danh sách liên kết có phải là palindrome hay không bằng cách đảo ngược và so sánh.
        /// Time Complexity: O(N)
        /// Space Complexity: O(N) cho danh sách đã đảo ngược.
        /// </summary>
        public bool IsPalindromeReverseAndCompare(LinkedList list)
        {
            if (list.Head == null || list.Head.Next == null) return true;

            Node? reversedListHead = ReverseAndClone(list.Head);
            return AreListsEqual(list.Head, reversedListHead);
        }

        private Node? ReverseAndClone(Node? node)
        {
            Node? head = null;
            while (node != null)
            {
                Node newNode = new Node(node.Data); // Sao chép nút
                newNode.Next = head;
                head = newNode;
                node = node.Next;
            }
            return head;
        }

        private bool AreListsEqual(Node? list1, Node? list2)
        {
            while (list1 != null && list2 != null)
            {
                if (list1.Data != list2.Data)
                {
                    return false;
                }
                list1 = list1.Next;
                list2 = list2.Next;
            }
            return list1 == null && list2 == null; // Cả hai phải là null nếu có cùng độ dài
        }

        /// <summary>
        /// Kiểm tra xem một danh sách liên kết có phải là palindrome hay không bằng cách sử dụng ngăn xếp.
        /// Time Complexity: O(N)
        /// Space Complexity: O(N) cho ngăn xếp (lưu trữ khoảng N/2 phần tử).
        /// </summary>
        public bool IsPalindromeStack(LinkedList list)
        {
            if (list.Head == null || list.Head.Next == null) return true;

            Node? slow = list.Head;
            Node? fast = list.Head;
            Stack<int> stack = new Stack<int>();

            // Đẩy nửa đầu của các phần tử vào ngăn xếp
            while (fast != null && fast.Next != null)
            {
                if (slow != null && fast != null)
                {
                    stack.Push(slow.Data);
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }
            }

            // Nếu danh sách có số lượng phần tử lẻ, bỏ qua phần tử ở giữa
            if (fast != null)
            {
                if (slow != null)
                {
                    slow = slow.Next;
                }
            }

            // So sánh nửa sau của các phần tử với ngăn xếp
            while (slow != null)
            {
                int top = stack.Pop();
                if (top != slow.Data)
                {
                    return false;
                }
                slow = slow.Next;
            }
            return true;
        }
    }
}
