// Problems/Problem_2_4_Partition.cs
namespace LinkedListAlgorithms.Problems
{
    public class Problem_2_4_Partition
    {
        /// <summary>
        /// Phân vùng một danh sách liên kết xung quanh một giá trị x, sao cho tất cả các nút nhỏ hơn x đứng trước
        /// tất cả các nút lớn hơn hoặc bằng x. Phiên bản này ổn định.
        /// Time Complexity: O(N)
        /// Space Complexity: O(N) cho danh sách mới, hoặc O(1) nếu sửa đổi tại chỗ (phức tạp hơn).
        /// Việc triển khai này tạo ra các đoạn danh sách mới.
        /// </summary>
        public LinkedList Solve(LinkedList list, int x)
        {
            if (list.Head == null) return new LinkedList(); // Trả về danh sách trống

            Node? beforeStart = null;
            Node? beforeEnd = null;
            Node? afterStart = null;
            Node? afterEnd = null;
            Node? current = list.Head;

            while (current != null)
            {
                Node? nextNode = current.Next;
                current.Next = null; // Tách nút

                if (current.Data < x)
                {
                    if (beforeStart == null) // Nút đầu tiên cho danh sách 'trước'
                    {
                        beforeStart = current;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        if (beforeEnd != null)
                        {
                            beforeEnd.Next = current;
                        }
                        beforeEnd = current;
                    }
                }
                else // Dữ liệu nút >= x
                {
                    if (afterStart == null) // Nút đầu tiên cho danh sách 'sau'
                    {
                        afterStart = current;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        if (afterEnd != null)
                        {
                            afterEnd.Next = current;
                        }
                        afterEnd = current;
                    }
                }
                current = nextNode;
            }

            LinkedList resultList = new LinkedList();
            if (beforeStart == null) // Tất cả các phần tử đều >= x
            {
                resultList.Head = afterStart;
                return resultList;
            }

            // Hợp nhất danh sách 'trước' và 'sau'
            if (beforeEnd != null)
            {
                beforeEnd.Next = afterStart;
            }
            resultList.Head = beforeStart;
            return resultList;
        }
    }
}
