namespace BitManipulation
{
    /// <summary>
    /// 5.4 - Tìm số nhị phân lớn hơn và nhỏ hơn gần nhất có cùng số lượng bit 1
    /// 
    /// Ví dụ: n = 13948 = 11011001111100
    /// ▸ Số lớn hơn gần nhất  = 11011010011111 = 13967
    /// ▸ Số nhỏ hơn gần nhất  = 11011001111010 = 13946
    /// 
    /// Cách tiếp cận:
    /// 1. Số lớn hơn (GetNext):
    ///    - Tìm bit 0 phải nhất không phải trailing zero
    ///    - Bật bit này thành 1
    ///    - Đẩy các bit 1 còn lại về cuối (để được số nhỏ nhất có thể)
    /// 
    /// 2. Số nhỏ hơn (GetPrev):
    ///    - Tìm bit 1 phải nhất không phải trailing one
    ///    - Tắt bit này thành 0
    ///    - Đẩy các bit 1 còn lại sát về bên phải bit vừa tắt
    /// </summary>
    public class NextNumber
    {
        /// <summary>
        /// Tìm số nhị phân nhỏ nhất lớn hơn n có cùng số lượng bit 1
        /// </summary>
        public int GetNext(int n)
        {
            // 1. Đếm số lượng trailing 0s và 1s
            int c = n;
            int c0 = 0;  // số lượng trailing zeros
            int c1 = 0;  // số lượng ones liền kề trailing zeros

            // Đếm trailing zeros
            while ((c & 1) == 0 && c != 0)
            {
                c0++;
                c >>= 1;
            }

            // Đếm ones liền kề
            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            // 2. Kiểm tra có tồn tại số lớn hơn không
            int p = c0 + c1;  // vị trí bit cần flip
            if (p == 31 || p == 0)
                return -1;  // không tồn tại số lớn hơn

            // 3. Tạo số lớn hơn gần nhất
            n |= (1 << p);                    // bật bit p thành 1
            n &= ~((1 << p) - 1);            // xoá tất cả bits thấp hơn p
            n |= (1 << (c1 - 1)) - 1;        // thêm (c1-1) bits 1 vào cuối

            return n;
        }

        /// <summary>
        /// Tìm số nhị phân lớn nhất nhỏ hơn n có cùng số lượng bit 1
        /// </summary>
        public int GetPrev(int n)
        {
            // 1. Đếm số lượng trailing 1s và 0s
            int temp = n;
            int c1 = 0;  // số lượng trailing ones
            int c0 = 0;  // số lượng zeros liền kề trailing ones

            // Đếm trailing ones
            while ((temp & 1) == 1)
            {
                c1++;
                temp >>= 1;
            }

            // Kiểm tra nếu số toàn 1s
            if (temp == 0)
                return -1;  // không tồn tại số nhỏ hơn

            // Đếm zeros liền kề
            while ((temp & 1) == 0 && temp != 0)
            {
                c0++;
                temp >>= 1;
            }

            // 2. Tạo số nhỏ hơn gần nhất
            int p = c0 + c1;                  // vị trí bit cần flip
            n &= (~0) << (p + 1);            // giữ nguyên các bits từ p+1 trở lên
            int mask = (1 << (c1 + 1)) - 1;   // tạo (c1+1) bits 1
            n |= mask << (c0 - 1);           // đặt các bits 1 vào đúng vị trí

            return n;
        }
    }
}
