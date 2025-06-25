
using System;
using System.Text;

namespace LinkedListAlgorithms
{
    /// <summary>
    /// Đại diện cho một danh sách liên kết đơn.
    /// </summary>
    public class LinkedList
    {
        public Node? Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }

        /// <summary>
        /// Nối một nút mới với dữ liệu đã cho vào cuối danh sách.
        /// </summary>
        public void Append(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        /// <summary>
        /// Nối một nút hiện có vào cuối danh sách.
        /// Được sử dụng cho các bài toán như Giao điểm nơi nhận dạng nút quan trọng.
        /// </summary>
        public void AppendNode(Node node)
        {
            if (node == null) return;
            node.Next = null; // Đảm bảo nó là đuôi mới

            if (Head == null)
            {
                Head = node;
                return;
            }
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
        }

        /// <summary>
        /// In các phần tử của danh sách liên kết.
        /// </summary>
        public void PrintList()
        {
            Node? current = Head;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.Data + " -> ");
                current = current.Next;
            }
            sb.Append("null");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// In các phần tử của danh sách liên kết (sử dụng char cho các ví dụ cụ thể).
        /// </summary>
        public void PrintListAsChars()
        {
            Node? current = Head;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append((char)current.Data + " -> ");
                current = current.Next;
            }
            sb.Append("null");
            Console.WriteLine(sb.ToString());
        }
    }
}
