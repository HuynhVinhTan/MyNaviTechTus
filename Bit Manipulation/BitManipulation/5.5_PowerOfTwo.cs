namespace BitManipulation
{
    /// <summary>
    /// 5.5 - Kiểm tra một số có phải lũy thừa của 2 hay không
    /// 
    /// Cách tiếp cận: Sử dụng biểu thức (n & (n-1)) == 0
    /// 
    /// Giải thích:
    /// 1. Lũy thừa của 2 luôn có dạng: 1000...0 (chỉ có 1 bit 1)
    ///    Ví dụ: 8 = 1000, 16 = 10000
    /// 
    /// 2. Khi trừ 1, ta được:          0111...1 (tất cả bits phải của bit 1 bị lật)
    ///    Ví dụ: 7 = 0111, 15 = 01111
    /// 
    /// 3. Khi AND hai số này:
    ///    1000...0 & 0111...1 = 0
    ///    → Chỉ có lũy thừa của 2 mới cho kết quả 0
    /// 
    /// Ví dụ:
    /// ▸ n = 8  = 1000, n-1 = 7  = 0111 → 1000 & 0111 = 0000 ✓
    /// ▸ n = 12 = 1100, n-1 = 11 = 1011 → 1100 & 1011 = 1000 ✗
    /// 
    /// Lưu ý: Cần kiểm tra n > 0 vì 0 cũng thoả (0 & -1) == 0
    /// </summary>
    public class PowerOfTwo
    {
        /// <summary>
        /// Kiểm tra n có phải là lũy thừa của 2 hay không
        /// </summary>
        /// <param name="n">Số cần kiểm tra</param>
        /// <returns>true nếu n là lũy thừa của 2, false nếu không phải</returns>
        public bool Execute(int n) => n > 0 && (n & (n - 1)) == 0;
    }
}
