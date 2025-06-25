namespace BitManipulation
{
    /// <summary>
    /// 5.3 - Tìm chuỗi bit 1 dài nhất có thể đạt được bằng cách lật 1 bit 0 thành 1.
    /// Ví dụ: 11011101111 (1775) → 8 (lật bit 0 ở giữa)
    /// 
    /// Cách tiếp cận:
    /// 1. Nếu tất cả là bit 1 → trả về 32
    /// 2. Duyệt từng bit, theo dõi:
    ///    - currentLen: độ dài chuỗi 1 hiện tại
    ///    - prevLen: độ dài chuỗi 1 trước đó (trước bit 0)
    /// 3. Khi gặp bit 0:
    ///    - Nếu bit kế tiếp là 1: lưu currentLen vào prevLen
    ///    - Nếu bit kế tiếp là 0: reset prevLen = 0
    /// 4. Kết quả là max(prevLen + 1 + currentLen) trong quá trình duyệt
    /// </summary>
    public class FlipBitToWin
    {
        public int Execute(int n)
        {
            // Trường hợp đặc biệt: tất cả là bit 1
            if (~n == 0) return 32;

            int currentLen = 0;  // độ dài chuỗi 1 hiện tại
            int prevLen = 0;     // độ dài chuỗi 1 trước bit 0
            int maxLen = 1;      // kết quả - độ dài lớn nhất có thể

            // Duyệt từng bit
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    currentLen++;
                }
                else
                {
                    // Kiểm tra bit kế tiếp
                    // Nếu bit kế = 0 → không thể nối 2 chuỗi → prevLen = 0
                    // Nếu bit kế = 1 → có thể nối → prevLen = currentLen
                    prevLen = ((n & 2) == 0) ? 0 : currentLen;
                    currentLen = 0;
                }

                // Cập nhật kết quả: prevLen + 1 (bit được lật) + currentLen
                maxLen = System.Math.Max(maxLen, prevLen + 1 + currentLen);
                n >>= 1;
            }

            return maxLen;
        }
    }
}
