namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_5_SumLists
    {
        /// <summary>
        /// Cộng hai số được biểu thị bằng danh sách liên kết, trong đó các chữ số được lưu trữ theo thứ tự ngược.
        /// Ví dụ: (7->1->6) + (5->9->2) có nghĩa là 617 + 295. Kết quả: (2->1->9) có nghĩa là 912.
        /// Time Complexity: O(max(N, M)) trong đó N và M là độ dài của danh sách.
        /// Space Complexity: O(max(N, M)) cho danh sách kết quả.
        /// </summary>
        public LinkedList SumListsReverseOrder(LinkedList list1, LinkedList list2)
        {
            Node? l1 = list1?.Head;
            Node? l2 = list2?.Head;
            LinkedList resultList = new LinkedList();
            Node? resultTail = null;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int val1 = (l1 != null) ? l1.Data : 0;
                int val2 = (l2 != null) ? l2.Data : 0;

                int sum = val1 + val2 + carry;
                int digit = sum % 10;
                carry = sum / 10;

                Node newNode = new Node(digit);
                if (resultList.Head == null)
                {
                    resultList.Head = newNode;
                    resultTail = resultList.Head;
                }
                else
                {
                    if (resultTail != null)
                    {
                        resultTail.Next = newNode;
                        resultTail = resultTail.Next;
                    }
                }

                if (l1 != null) l1 = l1.Next;
                if (l2 != null) l2 = l2.Next;
            }
            return resultList;
        }

        // Lớp trợ giúp cho SumListsForwardOrder
        private class PartialSum
        {
            public Node? SumNode { get; set; } = null;
            public int Carry { get; set; } = 0;
        }

        /// <summary>
        /// Cộng hai số được biểu thị bằng danh sách liên kết, trong đó các chữ số được lưu trữ theo thứ tự xuôi.
        /// Ví dụ: (6->1->7) + (2->9->5) có nghĩa là 617 + 295. Kết quả: (9->1->2) có nghĩa là 912.
        /// Time Complexity: O(N+M)
        /// Space Complexity: O(N+M) cho ngăn xếp đệ quy và danh sách kết quả.
        /// </summary>
        public LinkedList SumListsForwardOrder(LinkedList list1, LinkedList list2)
        {
            Node? l1 = list1?.Head;
            Node? l2 = list2?.Head;

            int len1 = GetLength(l1);
            int len2 = GetLength(l2);

            // Đệm danh sách ngắn hơn bằng các số 0 ở đầu
            if (len1 < len2)
            {
                l1 = PadList(l1, len2 - len1);
            }
            else if (len2 < len1)
            {
                l2 = PadList(l2, len1 - len2);
            }

            // Cộng danh sách theo cách đệ quy
            PartialSum sumResult = AddListsForwardHelper(l1, l2);

            LinkedList finalResult = new LinkedList();
            // Nếu còn số nhớ, chèn nó vào đầu
            if (sumResult.Carry > 0)
            {
                finalResult.Head = InsertBefore(sumResult.SumNode, sumResult.Carry);
            }
            else
            {
                finalResult.Head = sumResult.SumNode;
            }
            return finalResult;
        }

        private PartialSum AddListsForwardHelper(Node? l1, Node? l2)
        {
            if (l1 == null && l2 == null) // Trường hợp cơ sở cho đệ quy
            {
                return new PartialSum();
            }

            // Đệ quy cho các nút tiếp theo
            PartialSum nextSum = AddListsForwardHelper(l1?.Next, l2?.Next);

            // Tính tổng cho các chữ số hiện tại
            int currentVal = nextSum.Carry + (l1?.Data ?? 0) + (l2?.Data ?? 0);
            int currentDigit = currentVal % 10;
            
            // Thêm chữ số hiện tại vào đầu danh sách tổng
            Node currentSumNode = InsertBefore(nextSum.SumNode, currentDigit);

            return new PartialSum { SumNode = currentSumNode, Carry = currentVal / 10 };
        }

        private int GetLength(Node? node)
        {
            int length = 0;
            while (node != null)
            {
                length++;
                node = node.Next;
            }
            return length;
        }

        private Node? PadList(Node? node, int paddingCount)
        {
            Node? head = node;
            for (int i = 0; i < paddingCount; i++)
            {
                head = InsertBefore(head, 0);
            }
            return head;
        }

        private Node InsertBefore(Node? listNode, int data)
        {
            Node newNode = new Node(data);
            if (listNode != null)
            {
                newNode.Next = listNode;
            }
            return newNode;
        }
    }
}
