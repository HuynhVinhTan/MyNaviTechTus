namespace BitManipulation
{
    /// <summary>
    /// 5.6 - Đếm số bit cần lật để chuyển số A thành số B
    /// 
    /// Cách tiếp cận:
    /// 1. Sử dụng XOR (^) để tìm các bit khác nhau giữa A và B
    ///    - Bit 1 trong kết quả XOR → bit khác nhau
    ///    - Bit 0 trong kết quả XOR → bit giống nhau
    /// 
    /// 2. Đếm số bit 1 trong kết quả XOR (Hamming weight) bằng kỹ thuật:
    ///    while (x != 0) { x &= (x-1); count++; }
    ///    - Mỗi lần lặp sẽ xoá đi bit 1 phải nhất
    ///    - Số lần lặp = số bit 1
    /// 
    /// Ví dụ:
    /// A = 29 (11101)
    /// B = 15 (01111)
    /// A ^ B = (10010) → 2 bit cần lật (bit 1 và bit 4)
    /// 
    /// Giải thích chi tiết:
    /// 1. XOR:
    ///    11101 (29)
    ///    01111 (15)
    ///    ----- XOR
    ///    10010 (kết quả)
    /// 
    /// 2. Đếm số bit 1:
    ///    10010 & 10001 = 10000 (lần 1)
    ///    10000 & 01111 = 00000 (lần 2)
    ///    → 2 bit cần lật
    /// </summary>
    public class BitSwapsRequired
    {
        /// <summary>
        /// Đếm số bit cần lật để chuyển số A thành số B
        /// </summary>
        /// <param name="a">Số nguồn</param>
        /// <param name="b">Số đích</param>
        /// <returns>Số bit cần lật để chuyển A thành B</returns>
        public int Execute(int a, int b)
        {
            int count = 0;
            // XOR để tìm các bit khác nhau, sau đó đếm số bit 1
            for (int c = a ^ b; c != 0; c &= (c - 1))
                count++;
            return count;
        }
    }
}
